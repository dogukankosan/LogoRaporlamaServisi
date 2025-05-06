using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NoktaBilgiNotificationService.Classes
{
   internal class EMailManager
    {
        internal async static void ErrorMailSend(string errorMessage)
        {
            try
            {
                bool mailSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSettingsError LIMIT 1");
                if (!mailSettings)
                    return;
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSettingsError LIMIT 1");
                string senderEmail = dt.Rows[0]["MailAdress"].ToString();
                string recipientEmail = senderEmail;
                string senderPassword = EncryptionHelper.Decrypt(dt.Rows[0]["Password"].ToString());
                string server = dt.Rows[0]["ServerName"].ToString();
                int port = Convert.ToInt32(dt.Rows[0]["Port"]);
                bool ssl = Convert.ToBoolean(dt.Rows[0]["SSL"]);
                string companyName = dt.Rows[0]["CompanyName"].ToString();
                string subject = $"{companyName} Firmasında Otomatik Raporlama Programında Hata Mesajı";
                using (SmtpClient client = new SmtpClient(server, port))
                {
                    client.EnableSsl = ssl;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(senderEmail),
                        Subject = subject,
                        Body = errorMessage
                    };
                    mail.To.Add(recipientEmail);
                    await client.SendMailAsync(mail);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        internal async static Task<bool> OrderMailSend(
string senderEmail,
string recipientEmail,
string senderPassword,
string server,
int port,
bool ssl,
byte[] pdfPath,
string personel,
string reportName,
string reportDesc            )
        {
            DataTable signMail =await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSignature LIMIT 1");
            string htmlSignature = "";
            if (signMail != null && signMail.Rows.Count > 0)
            {
                string name = signMail.Rows[0]["CompanyName"]?.ToString();
                string phone = signMail.Rows[0]["Phone"]?.ToString();
                string address = signMail.Rows[0]["Adress"]?.ToString();
                string website = signMail.Rows[0]["CompanyWebSite"]?.ToString();
                string rawBase64 = signMail.Rows[0]["CompanyImage"]?.ToString();
                string logoBase64 = string.IsNullOrWhiteSpace(rawBase64) ? "" : "data:image/png;base64," + rawBase64;
                if (!string.IsNullOrWhiteSpace(name) &&
                    !string.IsNullOrWhiteSpace(phone) &&
                    !string.IsNullOrWhiteSpace(address) &&
                    !string.IsNullOrWhiteSpace(website))
                {
                    htmlSignature = $@"
<br/>
<hr />
<table style='font-family: Arial, sans-serif; font-size: 14px;'>
    <tr>
        <td style='vertical-align: top; padding-right: 15px;'>
            <img src='cid:firmaLogo' alt='Firma Logo' style='width: 150px; height: auto; border-radius: 5px;'/>
        </td>
        <td style='vertical-align: top;'>
            <p style='margin: 0;'><strong style='font-size: 16px; color: #333;'>{name}</strong></p>
            <p style='margin: 2px 0;'>📞 <a href='tel:{phone}' style='color: #000; text-decoration: none;'>{phone}</a></p>
            <p style='margin: 2px 0;'>💬 <a href='https://wa.me/{phone.Replace("+", "").Replace(" ", "")}' style='color: #25D366; text-decoration: none;'>WhatsApp ile yaz</a></p>
            <p style='margin: 2px 0;'>📍 {address}</p>
            <p style='margin: 2px 0;'>🌐 <a href='https://{website}' style='color: #1a0dab;' target='_blank'>{website}</a></p>
        </td>
    </tr>
</table>";
                }
            }
            string subject = $"{reportName} Raporu";
            string body = $@"
<html>
<body>
    <p>Sayın <strong>{personel}</strong>,Logo sisteminden oluşturulan <strong>{reportName}</strong> raporunuz {reportDesc} raporunuz ekte sunulmuştur.

    {htmlSignature}
</body>
</html>";
            try
            {
                using (SmtpClient client = new SmtpClient(server, port))
                {
                    client.EnableSsl = ssl;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(senderEmail),
                        Subject = subject,
                        IsBodyHtml = true
                    };
                    mail.To.Add(recipientEmail);
                    string rawBase64 = signMail.Rows[0]["CompanyImage"]?.ToString();
                    byte[] logoBytes = Convert.FromBase64String(rawBase64);
                    MemoryStream logoStream = new MemoryStream(logoBytes);
                    LinkedResource inlineLogo = new LinkedResource(logoStream, MediaTypeNames.Image.Jpeg)
                    {
                        ContentId = "firmaLogo",
                        TransferEncoding = TransferEncoding.Base64,
                        ContentType = new ContentType(MediaTypeNames.Image.Jpeg)
                    };
                    inlineLogo.ContentType.Name = "LOGO";
                    AlternateView avHtml = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
                    avHtml.LinkedResources.Add(inlineLogo);
                    mail.AlternateViews.Add(avHtml);
                    if (pdfPath != null && pdfPath.Length > 0)
                    {
                        MemoryStream pdfStream = new MemoryStream(pdfPath);
                        Attachment pdfAttachment = new Attachment(pdfStream, $"{reportName}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                        mail.Attachments.Add(pdfAttachment);
                    }
                    await client.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging(ex.Message + " ---- " + ex.ToString());
                return false;
            }
            return true;
        }
    }
}