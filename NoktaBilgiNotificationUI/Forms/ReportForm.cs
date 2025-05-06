using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Classes;
using DevExpress.XtraGrid.Views.Base;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class ReportForm : XtraForm
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        private int selectedId = -1;
        private async void List()
        {
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync(@"
SELECT 
    Id AS 'Görev No',
    TaskName AS 'Görev Adı',
    IsActive AS 'Durum',
    StartTime AS 'Başlangıç Saati',
    RepeatEveryMinutes AS 'Tekrar Dakikası',
    Days AS 'Günler',
    LastRun AS 'Son Çalışma',
    SendType AS 'Gönderim Türü'
FROM SchedulerTasksReport
");
            gridControl1.DataSource = dt;
            UtilityHelper.CustomizeGridView(gridView1);
            if (gridView1.Columns.ColumnByFieldName("Durum") != null)
            {
                DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                repositoryComboBox.Items.AddRange(new string[] { "Pasif", "Aktif" });
                repositoryComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                gridView1.Columns["Durum"].ColumnEdit = repositoryComboBox;
                gridView1.Columns["Durum"].UnboundType = DevExpress.Data.UnboundColumnType.String;
                gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
                gridView1.CustomDrawCell += gridView1_CustomDrawCell;
            }
            if (gridView1.Columns.ColumnByFieldName("Son Çalışma") != null)
            {
                gridView1.Columns["Son Çalışma"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["Son Çalışma"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"; 
            }

        }
        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Durum" && e.CellValue != null && e.CellValue != DBNull.Value)
            {
                int value = Convert.ToInt32(e.CellValue);
                e.Appearance.ForeColor = value == 1 ? Color.Green : Color.Red;
            }
        }
        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Durum")
            {
                if (e.Value != null)
                {
                    int value = Convert.ToInt32(e.Value);
                    e.DisplayText = value == 1 ? "Aktif" : "Pasif";
                }
            }
            else if (e.Column.FieldName == "Günler")
            {
                if (e.Value != null)
                {
                    string daysValue = e.Value.ToString();
                    var dayMap = new Dictionary<string, string>()
            {
                { "Mon", "Pazartesi" },
                { "Tue", "Salı" },
                { "Wed", "Çarşamba" },
                { "Thu", "Perşembe" },
                { "Fri", "Cuma" },
                { "Sat", "Cumartesi" },
                { "Sun", "Pazar" }
            };
                    string[] parts = daysValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> translatedDays = new List<string>();
                    foreach (var part in parts)
                    {
                        if (dayMap.ContainsKey(part))
                            translatedDays.Add(dayMap[part]);
                    }
                    e.DisplayText = string.Join(", ", translatedDays);
                }
            }
        }
        private async void ReportForm_Load(object sender, EventArgs e)
        {
            bool SQLConnectStatus = await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            if (!SQLConnectStatus)
            {
                XtraMessageBox.Show("Önce SQL Bağlantı Ayarlarını Tamamlayınız", "SQL Bağlantı Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bool SQLConnectStatusWeb = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WebSettings LIMIT 1");
            if (!SQLConnectStatus)
            {
                XtraMessageBox.Show("Önce Web Seris Ayarlarını Tamamlayınız", "SQL Bağlantı Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bool dtWp = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM SchedulerTasksReport LIMIT 1");
            if (!dtWp)
                return;
            List();
            List();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDesignerForm fr = new ReportDesignerForm();
            fr.Text = "Yeni Rapor Ekle";
            fr.ShowDialog();
            List();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
                selectedId = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "Görev No"));
        }
        private async void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                XtraMessageBox.Show("Lütfen Değiştirilecek Kaydı Seçiniz", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE SchedulerTasksReport SET IsActive=1 WHERE Id=" + selectedId + "");
            List();
        }
        private async void passiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                XtraMessageBox.Show("Lütfen Değiştirilecek Kaydı Seçiniz", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE SchedulerTasksReport SET IsActive=0 WHERE Id=" + selectedId + "");
            List();
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDesignerForm fr = new ReportDesignerForm();
            fr.Text = "Rapor Güncelle";
            if (selectedId == -1)
            {
                XtraMessageBox.Show("Lütfen Değiştirilecek Kaydı Seçiniz", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fr.id = selectedId;
            fr.ShowDialog();
            List();
        }

        private async void wpSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                XtraMessageBox.Show("Lütfen Gönderilecek Kaydı Seçiniz", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool statusDataReport = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM SchedulerTasksReport WHERE ID=" + selectedId + " LIMIT 1");
            if (!statusDataReport)
            {
                XtraMessageBox.Show("Rapor Bulunamadı Listeden Tekrar Seçiniz", "Hatalı Rapor Sorgusu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool wpSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WhatsappSettings LIMIT 1");
            if (!wpSettings)
            {
                XtraMessageBox.Show("Whatsapp Ayarlarınızı Güncelleyiniz", "Hatalı Whatsapp Okuma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable reportData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM SchedulerTasksReport WHERE ID=" + selectedId + " LIMIT 1");
            DataTable connection = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            string sql = EncryptionHelper.Decrypt(reportData.Rows[0]["CommandPayload"].ToString());
            string reportName = reportData.Rows[0]["TaskName"].ToString();
            string reportDesc = reportData.Rows[0]["TaskDesc"].ToString();
            DataTable resultData = await SQLCrud.LoadDataIntoGridViewAsync(sql, connection.Rows[0]["SQLConnectString"].ToString());
            DataTable webData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM WebSettings LIMIT 1");
            DataTable customerID = await SQLCrud.LoadDataIntoGridViewAsync("SELECT TOP 1 * FROM CustomersNotification WITH (NOLOCK) WHERE CustomerName='" + webData.Rows[0]["CompanyName"].ToString() + "' AND CustomerToken='" + webData.Rows[0]["WebToken"].ToString() + "' AND CustomerPassword='" + webData.Rows[0]["WebPassword"].ToString() + "'", webData.Rows[0]["SQLConnectString"].ToString());
            if (customerID.Rows.Count <= 0 || customerID is null)
            {
                XtraMessageBox.Show("Web Sunucusundan Müşteri Bilgileri Alınamadı", "Hatalı SQL Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (Convert.ToInt32(EncryptionHelper.Decrypt(customerID.Rows[0]["WpCount"].ToString())) <= 0)
                {
                    XtraMessageBox.Show("Whatsapp Gönderim Sayınız Bitmiş Veya Okunamamıştır", "Hatalı Whatsapp Gönderim Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Whatsapp Gönderim Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable wpData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM WhatsappSettings LIMIT 1");
            string accountSid = EncryptionHelper.Decrypt(wpData.Rows[0]["WpClientID"].ToString());
            string authToken = EncryptionHelper.Decrypt(wpData.Rows[0]["WpToken"].ToString());
            string messagingServiceSid = EncryptionHelper.Decrypt(wpData.Rows[0]["WpServiceID"].ToString());
            string templateSid = EncryptionHelper.Decrypt(wpData.Rows[0]["TemplateID"].ToString());
            string personListStr = reportData.Rows[0]["SendPersonList"].ToString();
            if (string.IsNullOrWhiteSpace(personListStr))
            {
                XtraMessageBox.Show("Lütfen gönderilecek personelleri önce seçiniz.", "Hatalı Gönderim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var personIdList = personListStr.Split(',')
                                            .Where(x => int.TryParse(x, out _))
                                            .Select(x => Convert.ToInt32(x))
                                            .ToList();
            if (personIdList.Count == 0)
            {
                XtraMessageBox.Show("Geçerli personel ID'leri bulunamadı.", "Hatalı Gönderim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable allPersons = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM SendPerson WHERE Status_=1");
            var matchedRows = allPersons.AsEnumerable()
                                        .Where(r => personIdList.Contains(Convert.ToInt32(r["ID"])))
                                        .ToList();
            if (matchedRows.Count == 0)
            {
                XtraMessageBox.Show("Seçilen personellerin hiçbiri aktif değil.", "Hatalı Gönderim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable selectedPersons = matchedRows.CopyToDataTable();

            string query = @"
    INSERT INTO PDFSNotification (CustomerID, PDFFile)
    VALUES (@CustomerID, @PDFFile);
    SELECT SCOPE_IDENTITY();";

            byte[] excel = UtilityHelper.ExportToExcelBytes(resultData);
            int insertedId = 0;
            using (SqlConnection conn = new SqlConnection(EncryptionHelper.Decrypt(webData.Rows[0]["SQLConnectString"].ToString())))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID.Rows[0]["ID"].ToString());
                cmd.Parameters.AddWithValue("@PDFFile", excel);
                await conn.OpenAsync();
                object result = await cmd.ExecuteScalarAsync();
                insertedId = Convert.ToInt32(result);
            }
            if (insertedId == 0 || insertedId == -1)
            {
                XtraMessageBox.Show("PDF Web Sunucusuna Kaydedilemedi", "Hatalı SQL Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string token = $"{webData.Rows[0]["WebToken"].ToString()}|{webData.Rows[0]["WebPassword"].ToString()}|{insertedId}";
            string code = $"{token}";
            int wpCountVariable = int.Parse(EncryptionHelper.Decrypt(customerID.Rows[0]["WpCount"].ToString()));
            string kontroEnd = "";
            string kontrolError = "";
            foreach (DataRow row in selectedPersons.Rows)
            {
                string phone = row["PhoneNumber"].ToString();
                string name = row["NameSurname"].ToString();

                string contentVariables = JsonConvert.SerializeObject(new
                {
                    per = name,
                    taskname = reportName,
                    desc=reportDesc,
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
                        wpCountVariable = wpCountVariable - 1;

                        if (await SQLCrud.InserUpdateDelete($"UPDATE CustomersNotification SET WPCount='{EncryptionHelper.Encrypt(wpCountVariable.ToString())}' WHERE ID=" + customerID.Rows[0]["ID"].ToString() + "", webData.Rows[0]["SQLConnectString"].ToString()))
                        {
                            if (wpCountVariable <= 0)
                            {
                                kontroEnd = "Bitti";
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            XtraMessageBox.Show("Kontör İşlemi Hatalı", "Hatalı WP Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            wpCountVariable = -1;
                            break;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(message.ErrorMessage, "Hatalı WP Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrolError = "Hata";
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Hatalı WP Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextLog.TextLogging(ex.Message + " -- " + ex.ToString());
                    wpCountVariable = -1;
                    kontrolError = "Hata";
                    continue;
                }
            }
            if (wpCountVariable != -1)
            {
                XtraMessageBox.Show($"Mesaj Gönderimi Başarılı Kalan Whatsapp Kontör Sayınız: {wpCountVariable}", "Kalan Kontör Sayınız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (kontroEnd == "Bitti")
            {
                XtraMessageBox.Show("Kontörünüz Bitmiştir Lütfen Kontör Alımı Yapınız", "Hatalı WP Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kontrolError=="Hata")
            {
                XtraMessageBox.Show($"Mesaj Gönderimi Yaparken Hata Alındı", "Hatalı Wp Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                XtraMessageBox.Show("Lütfen Gönderilecek Kaydı Seçiniz", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool statusDataReport = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM SchedulerTasksReport WHERE ID=" + selectedId + " LIMIT 1");
            if (!statusDataReport)
            {
                XtraMessageBox.Show("Rapor Bulunamadı Listeden Tekrar Seçiniz", "Hatalı Rapor Sorgusu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool mailSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSettings LIMIT 1");
            if (!mailSettings)
            {
                XtraMessageBox.Show("Mail Ayarlarınızı Güncelleyiniz", "Hatalı Mail Okuma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable reportData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM SchedulerTasksReport WHERE ID=" + selectedId + " LIMIT 1");
            DataTable connection = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            string sql = EncryptionHelper.Decrypt(reportData.Rows[0]["CommandPayload"].ToString());
            string reportName = reportData.Rows[0]["TaskName"].ToString();
            string reportDesc = reportData.Rows[0]["TaskDesc"].ToString();
            DataTable resultData = await SQLCrud.LoadDataIntoGridViewAsync(sql, connection.Rows[0]["SQLConnectString"].ToString());
            DataTable webData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM WebSettings LIMIT 1");

            DataTable customerID = await SQLCrud.LoadDataIntoGridViewAsync("SELECT TOP 1 * FROM CustomersNotification WITH (NOLOCK) WHERE CustomerName='" + webData.Rows[0]["CompanyName"].ToString() + "' AND CustomerToken='" + webData.Rows[0]["WebToken"].ToString() + "' AND CustomerPassword='" + webData.Rows[0]["WebPassword"].ToString() + "'", webData.Rows[0]["SQLConnectString"].ToString());
            if (customerID.Rows.Count <= 0 || customerID is null)
            {
                XtraMessageBox.Show("Web Sunucusundan Müşteri Bilgileri Alınamadı", "Hatalı SQL Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (Convert.ToInt32(EncryptionHelper.Decrypt(customerID.Rows[0]["MailCount"].ToString())) <= 0)
                {
                    XtraMessageBox.Show("Mail Gönderim Sayınız Bitmiş Veya Okunamamıştır", "Hatalı Mail Gönderim Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Mail Gönderim Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string personListStr = reportData.Rows[0]["SendPersonList"].ToString();
            if (string.IsNullOrWhiteSpace(personListStr))
            {
                XtraMessageBox.Show("Lütfen gönderilecek personelleri önce seçiniz.", "Hatalı Gönderim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var personIdList = personListStr.Split(',')
                                            .Where(x => int.TryParse(x, out _))
                                            .Select(x => Convert.ToInt32(x))
                                            .ToList();
            if (personIdList.Count == 0)
            {
                XtraMessageBox.Show("Geçerli personel ID'leri bulunamadı.", "Hatalı Gönderim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable allPersons = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM SendPerson WHERE Status_=1");
            var matchedRows = allPersons.AsEnumerable()
                                        .Where(r => personIdList.Contains(Convert.ToInt32(r["ID"])))
                                        .ToList();
            if (matchedRows.Count == 0)
            {
                XtraMessageBox.Show("Seçilen personellerin hiçbiri aktif değil.", "Hatalı Gönderim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string kontrolEnd = "";
            string kontrolError = "";
            DataTable selectedPersons = matchedRows.CopyToDataTable();
            int wpCountVariable = int.Parse(EncryptionHelper.Decrypt(customerID.Rows[0]["MailCount"].ToString()));
            DataTable mailData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSettings LIMIT 1");
            byte[] excel = UtilityHelper.ExportToExcelBytes(resultData);
            foreach (DataRow row in selectedPersons.Rows)
            {
                string mail = row["MailAdress"].ToString();
                string name = row["NameSurname"].ToString();

                bool mailStatus=await EMailManager.OrderMailSend(mailData.Rows[0]["MailAdress"].ToString(), mail, EncryptionHelper.Decrypt(mailData.Rows[0]["Password"].ToString()), mailData.Rows[0]["ServerName"].ToString(), int.Parse(mailData.Rows[0]["Port"].ToString()), mailData.Rows[0]["SSL"].ToString() == "1" ? true : false, excel,name,reportName, reportDesc);
                if (!mailStatus)
                {
                    kontrolError = "Hata";
                    continue;
                }
                wpCountVariable = wpCountVariable - 1;
                if (await SQLCrud.InserUpdateDelete($"UPDATE CustomersNotification SET MailCount='{EncryptionHelper.Encrypt(wpCountVariable.ToString())}' WHERE ID=" + customerID.Rows[0]["ID"].ToString() + "", webData.Rows[0]["SQLConnectString"].ToString()))
                {
                    if (wpCountVariable <= 0)
                    {
                        kontrolEnd = "Bitti";
                        break;
                    }
                    continue;
                }
                else
                {
                    XtraMessageBox.Show("Kontör İşlemi Hatalı", "Hatalı Mail Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    wpCountVariable = -1;
                    break;
                }
            }
            if (wpCountVariable != -1)
            {
                XtraMessageBox.Show($"Mesaj Gönderimi Başarılı Kalan Mail Kontör Sayınız: {wpCountVariable}", "Kalan Kontör Sayınız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (kontrolEnd == "Bitti")
            {
                XtraMessageBox.Show("Kontörünüz Bitmiştir Lütfen Kontör Alımı Yapınız", "Hatalı Mail Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kontrolError=="Hata")
            {
                XtraMessageBox.Show("Mail Gönderimi Sırasında Hatalı OLuştur", "Hatalı Mail Gönderimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
        private async void btn_ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                XtraMessageBox.Show("Lütfen Gönderilecek Kaydı Seçiniz", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable connection=await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            DataTable reportData = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT CommandPayload FROM SchedulerTasksReport WHERE ID=" + selectedId + " LIMIT 1");
            DataTable report=await SQLCrud.LoadDataIntoGridViewAsync(EncryptionHelper.Decrypt(reportData.Rows[0][0].ToString()), connection.Rows[0]["SQLConnectString"].ToString());
            byte[] excel = UtilityHelper.ExportToExcelBytes(report);
            string tempFilePath = Path.Combine(Path.GetTempPath(), $"Rapor_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            try
            {
                File.WriteAllBytes(tempFilePath, excel);
                Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Excel dosyası açılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}