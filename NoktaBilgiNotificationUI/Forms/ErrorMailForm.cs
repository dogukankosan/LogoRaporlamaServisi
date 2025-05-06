using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using NoktaBilgiNotificationUI.Classes;
using NoktaBilgiNotificationUI.Business;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class ErrorMailForm : XtraForm
    {
        public ErrorMailForm()
        {
            InitializeComponent();
        }
        private bool status = false;
        private async void btn_Update_Click(object sender, EventArgs e)
        {

            if (status)
            {
                if (EMailSettingLogic.EmailControl(txt_Email, txt_Password, txt_Server, txt_Port))
                {
                    if (string.IsNullOrEmpty(txt_CompanyName.Text.Trim()))
                    {
                        XtraMessageBox.Show("Şirket Adı Boş Geçilemez", "Hatalı Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_CompanyName.Focus();
                        return;
                    }
                    var dbMailStatus = await SQLiteCrud.InsertUpdateDeleteAsync(
      "UPDATE MailSettingsError SET MailAdress='"+txt_Email.Text.Trim()+"' , Password = '" + EncryptionHelper.Encrypt(txt_Password.Text) + "' , ServerName = '" + txt_Server.Text.Trim() + "', Port = " + txt_Port.Text.Trim() + ", SSl = " + (chk_SSL.Checked ? 1 : 0) + " , CompanyName ='"+txt_CompanyName.Text.Trim()+"'"
  );
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

        private async void btn_SendMail_Click(object sender, EventArgs e)
        {
            if (EMailSettingLogic.EmailControl(txt_Email, txt_Password, txt_Server, txt_Port))
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

        private async void ErrorMailForm_Load(object sender, EventArgs e)
        {
            txt_Port.Properties.Mask.MaskType = MaskType.Numeric;
            txt_Port.Properties.Mask.EditMask = "d";
            txt_Port.Properties.Mask.UseMaskAsDisplayFormat = true;
            bool mailSettings = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM MailSettingsError LIMIT 1");
            if (mailSettings)
            {
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM MailSettingsError LIMIT 1");
                txt_Email.Text = dt.Rows[0]["MailAdress"].ToString();
                txt_Password.Text = EncryptionHelper.Decrypt(dt.Rows[0]["Password"].ToString());
                txt_Server.Text = dt.Rows[0]["ServerName"].ToString();
                txt_Port.Text = dt.Rows[0]["Port"].ToString();
                chk_SSL.Checked = Convert.ToBoolean(dt.Rows[0]["SSL"]);
                txt_CompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            }
        }
    }
}