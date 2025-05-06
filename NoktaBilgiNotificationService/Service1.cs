using Newtonsoft.Json;
using NoktaBilgiNotificationService.Classes;
using Quartz;
using Quartz.Impl;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NoktaBilgiNotificationService
{
    public partial class Service1 : ServiceBase
    {
        private IScheduler scheduler;

        public Service1() => InitializeComponent();
        protected override async void OnStart(string[] args)
        {
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create<ReportJob>()
                .WithIdentity("reportJob", "group1")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("reportTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, trigger);
        }
        protected override async void OnStop()
        {
            if (scheduler != null)
                await scheduler.Shutdown();
        }
    }
    public class ReportJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                if (!await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1") ||
                    !await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WebSettings LIMIT 1"))
                    return;

                var sqlconnectData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
                string sqlConnectString = sqlconnectData.Rows[0]["SQLConnectString"].ToString();

                var webData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM WebSettings LIMIT 1");
                DateTime now = DateTime.Now;
                string gunKisaltmasi = now.ToString("ddd", System.Globalization.CultureInfo.InvariantCulture);

                var reports = await SQLiteCrud.GetDataFromSQLiteAsync($@"
            SELECT * FROM SchedulerTasksReport 
            WHERE IsActive = 1 AND Days LIKE '%{gunKisaltmasi}%'");

                foreach (DataRow row in reports.Rows)
                {
                    if (!TimeSpan.TryParse(row["StartTime"].ToString(), out TimeSpan startTime))
                        continue;

                    int repeatMinutes = Convert.ToInt32(row["RepeatEveryMinutes"]);
                    DateTime todayStart = now.Date.Add(startTime);
                    DateTime? lastRun = row["LastRun"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["LastRun"]);

                    bool shouldRun = false;

                    if (lastRun == null)
                    {
                        // İlk çalıştırma sadece StartTime saatindeyse çalışsın
                        if (now >= todayStart && now < todayStart.AddMinutes(1))
                            shouldRun = true;
                    }
                    else
                    {
                        DateTime nextRun = lastRun.Value.AddMinutes(repeatMinutes);
                        if (now >= nextRun)
                            shouldRun = true;
                    }

                    if (!shouldRun)
                        continue;

                    string commandText = EncryptionHelper.Decrypt(row["CommandPayload"].ToString());
                    string taskName = row["TaskName"].ToString();
                    string taskDesc = row["TaskDesc"].ToString();
                    string sendType = row["SendType"].ToString();
                    string sendList = row["SendPersonList"].ToString();

                    if (sendType == "Whatsapp")
                        await SendWhatsappAsync(sendList, commandText, taskName, taskDesc, webData, sqlConnectString);
                    else if (sendType == "Mail")
                        await SendMailAsync(sendList, commandText, taskName, taskDesc, webData, sqlConnectString);
                    else if (sendType == "Gönderim Yapılmıyacak")
                        await SendNoActionAsync(commandText, taskName, sqlConnectString);

                    int id = Convert.ToInt32(row["Id"]);
                    await SQLiteCrud.InsertUpdateDeleteAsync($"UPDATE SchedulerTasksReport SET LastRun = datetime('now', 'localtime') WHERE Id = {id}");
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging(ex.Message + " -- " + ex,"1");
            }
        }
        private async Task SendNoActionAsync(string commandText, string taskName, string sqlConnectString)
        {
            try
            {
                bool affectedRows = await SQLCrud.InserUpdateDelete(commandText, sqlConnectString);
            }
            catch (Exception ex)
            {
                TextLog.TextLogging($"{taskName} - Komut çalıştırılırken hata oluştu: {ex.Message} -- {ex}","1");
            }
        }
        private async Task SendMailAsync(string sendList, string commandText, string taskName, string taskDesc, DataTable webData, string sqlConnectString)
        {
            if (string.IsNullOrWhiteSpace(sendList))
            {
                TextLog.TextLogging(taskName + "Lütfen gönderilecek personelleri önce seçiniz.","1");
                return;
            }
            bool mailSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSettings LIMIT 1");
            if (!mailSettings)
            {
                TextLog.TextLogging("Mail Ayarlarınızı Güncelleyiniz");
                return;
            }
            var mailData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSettings LIMIT 1");
            var customerID = await SQLCrud.LoadDataIntoGridViewAsync(
                $"SELECT TOP 1 * FROM CustomersNotification WHERE CustomerName='{webData.Rows[0]["CompanyName"]}' AND CustomerToken='{webData.Rows[0]["WebToken"]}' AND CustomerPassword='{webData.Rows[0]["WebPassword"]}'",
                webData.Rows[0]["SQLConnectString"].ToString());
            if (customerID.Rows.Count == 0) return;
            try
            {
                if (Convert.ToInt32(EncryptionHelper.Decrypt(customerID.Rows[0]["MailCount"].ToString())) <= 0)
                {
                    TextLog.TextLogging("Mail Gönderim Sayınız Bitmiş Veya Okunamamıştır","1");
                    return;
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging(ex.Message + " -- " + ex.ToString(),"1");
                return;
            }
            var personIdList = sendList.Split(',').Select(int.Parse).ToList();
            var allPersons = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM SendPerson WHERE Status_=1");
            var matchedRows = allPersons.AsEnumerable().Where(r => personIdList.Contains(Convert.ToInt32(r["ID"]))).ToList();
            if (!matchedRows.Any())
            {
                TextLog.TextLogging(taskName + " Seçilen personellerin hiçbiri aktif değil.","1");
                return;
            }
            DataTable resultData = await SQLCrud.LoadDataIntoGridViewAsync(commandText, sqlConnectString);
            byte[] excel = UtilityHelper.ExportToExcelBytes(resultData);
            int mailCountVariable = int.Parse(EncryptionHelper.Decrypt(customerID.Rows[0]["MailCount"].ToString()));
            foreach (var row in matchedRows)
            {
                string mail = row["MailAdress"].ToString();
                string name = row["NameSurname"].ToString();
                try
                {
                    bool mailStatus = await EMailManager.OrderMailSend(mailData.Rows[0]["MailAdress"].ToString(), mail, EncryptionHelper.Decrypt(mailData.Rows[0]["Password"].ToString()), mailData.Rows[0]["ServerName"].ToString(), int.Parse(mailData.Rows[0]["Port"].ToString()), mailData.Rows[0]["SSL"].ToString() == "1" ? true : false, excel, name, taskName, taskDesc);
                    if (mailStatus)
                    {
                        mailCountVariable--;
                        await SQLCrud.InserUpdateDelete($"UPDATE CustomersNotification SET MailCount='{EncryptionHelper.Encrypt(mailCountVariable.ToString())}' WHERE ID={customerID.Rows[0]["ID"]}", webData.Rows[0]["SQLConnectString"].ToString());
                        if (mailCountVariable <= 0)
                        {
                            TextLog.TextLogging("Kontörünüz Bitmiştir Lütfen Kontör Alımı Yapınız","1");
                            break;
                        }
                    }
                    else
                    {
                        TextLog.TextLogging($"{taskName}: Mail Gönderimi Hatası","1");
                    }
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging(ex.Message + " -- " + ex,"1");
                    continue;
                }
            }
        }
        private async Task SendWhatsappAsync(string sendList, string commandText, string taskName, string taskDesc, DataTable webData, string sqlConnectString)
        {
            if (string.IsNullOrWhiteSpace(sendList))
            {
                TextLog.TextLogging(taskName + "Lütfen gönderilecek personelleri önce seçiniz.","1");
                return;
            }
            bool wpSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WhatsappSettings LIMIT 1");
            if (!wpSettings)
            {
                TextLog.TextLogging("Whatsapp Ayarlarınızı Güncelleyiniz");
                return;
            }
            var wpData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM WhatsappSettings LIMIT 1");
            string accountSid = EncryptionHelper.Decrypt(wpData.Rows[0]["WpClientID"].ToString());
            string authToken = EncryptionHelper.Decrypt(wpData.Rows[0]["WpToken"].ToString());
            string messagingServiceSid = EncryptionHelper.Decrypt(wpData.Rows[0]["WpServiceID"].ToString());
            string templateSid = EncryptionHelper.Decrypt(wpData.Rows[0]["TemplateID"].ToString());
            var customerID = await SQLCrud.LoadDataIntoGridViewAsync(
                $"SELECT TOP 1 * FROM CustomersNotification WHERE CustomerName='{webData.Rows[0]["CompanyName"]}' AND CustomerToken='{webData.Rows[0]["WebToken"]}' AND CustomerPassword='{webData.Rows[0]["WebPassword"]}'",
                webData.Rows[0]["SQLConnectString"].ToString());
            if (customerID.Rows.Count == 0) return;
            try
            {
                if (Convert.ToInt32(EncryptionHelper.Decrypt(customerID.Rows[0]["WpCount"].ToString())) <= 0)
                {
                    TextLog.TextLogging("Whatsapp Gönderim Sayınız Bitmiş Veya Okunamamıştır","1");
                    return;
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging(ex.Message + " -- " + ex.ToString(),"1");
                return;
            }
            var personIdList = sendList.Split(',').Select(int.Parse).ToList();
            var allPersons = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM SendPerson WHERE Status_=1");
            var matchedRows = allPersons.AsEnumerable().Where(r => personIdList.Contains(Convert.ToInt32(r["ID"]))).ToList();
            if (!matchedRows.Any())
            {
                TextLog.TextLogging(taskName + " Seçilen personellerin hiçbiri aktif değil.","1");
                return;
            }
            DataTable resultData = await SQLCrud.LoadDataIntoGridViewAsync(commandText, sqlConnectString);
            byte[] excel = UtilityHelper.ExportToExcelBytes(resultData);
            string query = "INSERT INTO PDFSNotification (CustomerID, PDFFile) VALUES (@CustomerID, @PDFFile); SELECT SCOPE_IDENTITY();";
            int insertedId;
            using (SqlConnection conn = new SqlConnection(EncryptionHelper.Decrypt(webData.Rows[0]["SQLConnectString"].ToString())))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID.Rows[0]["ID"].ToString());
                cmd.Parameters.AddWithValue("@PDFFile", excel);
                await conn.OpenAsync();
                insertedId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            }
            if (insertedId <= 0)
            {
                TextLog.TextLogging(taskName + "PDF Web Sunucusuna Kaydedilemedi","1");
                return;
            }
            string code = $"{webData.Rows[0]["WebToken"]}|{webData.Rows[0]["WebPassword"]}|{insertedId}";
            int wpCountVariable = int.Parse(EncryptionHelper.Decrypt(customerID.Rows[0]["WpCount"].ToString()));
            foreach (var row in matchedRows)
            {
                string phone = row["PhoneNumber"].ToString();
                string name = row["NameSurname"].ToString();
                string contentVariables = JsonConvert.SerializeObject(new
                {
                    per = name,
                    taskname = taskName,
                    desc = taskDesc,
                    mergedParam = code
                });
                try
                {
                    TwilioClient.Init(accountSid, authToken);
                    var message = MessageResource.Create(
                        messagingServiceSid: messagingServiceSid,
                        to: new PhoneNumber($"whatsapp:{phone}"),
                        body: "",
                        contentSid: templateSid,
                        contentVariables: contentVariables
                    );
                    if (message.ErrorCode == null)
                    {
                        wpCountVariable--;
                        await SQLCrud.InserUpdateDelete($"UPDATE CustomersNotification SET WPCount='{EncryptionHelper.Encrypt(wpCountVariable.ToString())}' WHERE ID={customerID.Rows[0]["ID"]}", webData.Rows[0]["SQLConnectString"].ToString());
                        if (wpCountVariable <= 0)
                        {
                            TextLog.TextLogging("Kontörünüz Bitmiştir Lütfen Kontör Alımı Yapınız","1");
                            break;
                        }
                    }
                    else
                    {
                        TextLog.TextLogging($"Twilio Hatası: {message.ErrorMessage}","1");
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging(ex.Message + " -- " + ex,"1");
                    continue;

                }
            }
        }
    }
}