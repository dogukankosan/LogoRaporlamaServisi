using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Business;
using NoktaBilgiNotificationUI.Classes;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class WhatsappSettingsForm : XtraForm
    {
        public WhatsappSettingsForm()
        {
            InitializeComponent();
        }
        private async void WhatsappSettingsForm_Load(object sender, EventArgs e)
        {
            bool dtWp = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM WhatsappSettings LIMIT 1");
            if (!dtWp)
                return;
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM WhatsappSettings");
            try
            {
                txt_WpClientID.Text = EncryptionHelper.Decrypt(dt.Rows[0]["WpClientID"].ToString());
                txt_WpToken.Text = EncryptionHelper.Decrypt(dt.Rows[0]["WpToken"].ToString());
                txt_ServiceID.Text = EncryptionHelper.Decrypt(dt.Rows[0]["WpServiceID"].ToString());
                txt_TemplateID.Text = EncryptionHelper.Decrypt(dt.Rows[0]["TemplateID"].ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Okuma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextLog.TextLogging(ex.Message + " -- " + ex.ToString());
            }
            txt_WpClientID.Focus();
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (WhatsappSettingLogic.Control( txt_WpClientID, txt_WpToken, txt_ServiceID, txt_TemplateID))
            {
               var status= await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE WhatsappSettings SET WpClientID='" + EncryptionHelper.Encrypt(txt_WpClientID.Text.Trim()) + "',WpToken='" + EncryptionHelper.Encrypt(txt_WpToken.Text.Trim()) + "',WpServiceID='" + EncryptionHelper.Encrypt(txt_ServiceID.Text.Trim()) + "',TemplateID='" + EncryptionHelper.Encrypt(txt_TemplateID.Text.Trim()) + "'");
                if (status.Success)
                {
                    XtraMessageBox.Show("Whatsapp Ayarları Güncelleme İşlemi Başarılı", "Whatsapp Bağlantı Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Whatsapp Ayarları Güncelleme İşlemi Hatalı", "Whatsapp Bağlantı Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       txt_WpClientID.Focus();
                }      
            }
        }

        private void WhatsappSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}