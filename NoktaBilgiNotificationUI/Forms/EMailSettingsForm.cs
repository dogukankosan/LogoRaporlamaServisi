using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using NoktaBilgiNotificationUI.Business;
using NoktaBilgiNotificationUI.Classes;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class EMailSettingsForm : XtraForm
    {
        public EMailSettingsForm()
        {
            InitializeComponent();
        }
        private bool status = false;
        private async void btn_Update_Click(object sender, EventArgs e)
        {
            if (status)
            {
                if (EMailSettingLogic.EmailControl(txt_Email,  txt_Password, txt_Server, txt_Port))
                {
                    var dbMailStatus = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE MailSettings SET MailAdress='" + txt_Email.Text.Trim() + "',Password='" + EncryptionHelper.Encrypt(txt_Password.Text) + "',ServerName='" + txt_Server.Text.Trim() + "',Port=" + txt_Port.Text.Trim() + ",SSl=" + chk_SSL.Checked + "");
                    status = false;
                    if (dbMailStatus.Success)
                        XtraMessageBox.Show("Mail Güncelleme İşlemi Başarılı", "Mail Ayarları Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Mail Güncelleme İşlemi Hatalı", "Mail Ayarları Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                XtraMessageBox.Show("Önce Mailinizi Test Ediniz !!", "Mail Test Et", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (EMailSettingLogic.SaveMailSignature(txt_CompanyName, txt_Phone, txt_Adres, txt_Web, pictureEdit1))
            {
                string base64String = UtilityHelper.ImageToBase64(pictureEdit1.Image, System.Drawing.Imaging.ImageFormat.Png);
                var dbStatus = await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE MailSignature SET CompanyName='" + txt_CompanyName.Text.Trim() + "',Phone='" + txt_Phone.Text.Trim() + "',Adress='" + txt_Adres.Text.Trim() + "',CompanyWebSite='" + txt_Web.Text.Trim() + "' , CompanyImage= '" + base64String + "'");
                if (dbStatus.Success)
                    XtraMessageBox.Show("Mail İmza Güncelleme İşlemi Başarılı", "Mail İmza Ayarları Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Mail İmza Güncelleme İşlemi Hatalı", "Mail İmza Ayarları Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            status = false;
        }
        private async void btn_SendMail_Click(object sender, EventArgs e)
        {
            if (EMailSettingLogic.EmailControl(txt_Email,  txt_Password, txt_Server, txt_Port))
            {
                try
                {
                    int port = int.Parse(txt_Port.Text);
                    status = await EMailManager.TestMailSend(txt_Email.Text.Trim(), txt_Email.Text.Trim(), txt_Password.Text.Trim(), txt_Server.Text.Trim(), port, chk_SSL.Checked);
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging(ex.Message + " ---- " + ex.ToString());
                }
            }
        }
        private async void EMailSettingsForm_Load(object sender, EventArgs e)
        {
            txt_Port.Properties.Mask.MaskType = MaskType.Numeric;
            txt_Port.Properties.Mask.EditMask = "d";
            txt_Port.Properties.Mask.UseMaskAsDisplayFormat = true;
            bool mailSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSettings LIMIT 1");
            if (mailSettings)
            {
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSettings LIMIT 1");
                    txt_Email.Text = dt.Rows[0]["MailAdress"].ToString();
                    txt_Password.Text = EncryptionHelper.Decrypt(dt.Rows[0]["Password"].ToString());
                    txt_Server.Text = dt.Rows[0]["ServerName"].ToString();
                    txt_Port.Text = dt.Rows[0]["Port"].ToString();
                    chk_SSL.Checked = Convert.ToBoolean(dt.Rows[0]["SSL"]);
            }
            bool mailSettingsSign = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSignature LIMIT 1");
            if (!mailSettingsSign)
                return;
            DataTable signMail = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT *FROM MailSignature LIMIT 1");
            try
            {
                txt_CompanyName.Text = signMail.Rows[0]["CompanyName"].ToString();
                txt_Phone.Text = signMail.Rows[0]["Phone"].ToString();
                txt_Adres.Text = signMail.Rows[0]["Adress"].ToString();
                if (signMail.Rows.Count > 0 && (signMail.Rows[0]["CompanyImage"] != DBNull.Value && signMail.Rows[0]["CompanyImage"].ToString() != ""))
                {
                    string base64String = signMail.Rows[0]["CompanyImage"].ToString();
                    if (!string.IsNullOrEmpty(base64String))
                        pictureEdit1.Image = UtilityHelper.Base64ToImage(base64String);
                }
                txt_Web.Text = signMail.Rows[0]["CompanyWebSite"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Kayıt Okuma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextLog.TextLogging(ex.Message + " -- " + ex.ToString());
                return;
            }
        }

        private void EMailSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}