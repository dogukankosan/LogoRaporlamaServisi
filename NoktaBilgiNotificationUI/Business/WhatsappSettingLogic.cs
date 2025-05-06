using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace NoktaBilgiNotificationUI.Business
{
    internal class WhatsappSettingLogic
    {
        internal static bool Control(TextEdit clientID, TextEdit clientTokent, TextEdit serviceID, TextEdit templateID)
        {
            #region ClientID
            if (string.IsNullOrEmpty(clientID.Text.Trim()))
            {
                XtraMessageBox.Show("Whatsapp client ID kutusu boş geçilemez", "Hatalı Client ID Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientID.Focus();
                return false;
            }
            else if (clientID.Text.Trim().Length > 250)
            {
                XtraMessageBox.Show("Whatsapp client ID 250 karakterden fazla olamaz", "Hatalı Client ID Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientID.Focus();
                return false;
            }
            #endregion
            #region ClientTokent
            if (string.IsNullOrEmpty(clientTokent.Text.Trim()))
            {
                XtraMessageBox.Show("Whatsapp client token kutusu boş geçilemez", "Hatalı Client Token Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientTokent.Focus();
                return false;
            }
            else if (clientTokent.Text.Trim().Length > 250)
            {
                XtraMessageBox.Show("Whatsapp client token 250 karakterden fazla olamaz", "Hatalı Client Token Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clientTokent.Focus();
                return false;
            }
            #endregion
            #region ServiceID
            if (string.IsNullOrEmpty(serviceID.Text.Trim()))
            {
                XtraMessageBox.Show("Whatsapp service id kutusu boş geçilemez", "Hatalı Service ID Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serviceID.Focus();
                return false;
            }
            else if (serviceID.Text.Trim().Length > 250)
            {
                XtraMessageBox.Show("Whatsapp service id 250 karakterden fazla olamaz", "Hatalı Service ID Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serviceID.Focus();
                return false;
            }
            #endregion
            #region TemplateID
            if (string.IsNullOrEmpty(templateID.Text.Trim()))
            {
                XtraMessageBox.Show("Whatsapp template id kutusu boş geçilemez", "Hatalı Template ID Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                templateID.Focus();
                return false;
            }
            else if (templateID.Text.Trim().Length > 250)
            {
                XtraMessageBox.Show("Whatsapp template id 250 karakterden fazla olamaz", "Hatalı Template ID Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                templateID.Focus();
                return false;
            }
            #endregion
            return true;
        }
    }
}