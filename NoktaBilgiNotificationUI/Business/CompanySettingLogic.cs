using DevExpress.XtraEditors;
using System.Linq;
using System.Windows.Forms;

namespace NoktaBilgiNotificationUI.Business
{
    internal class CompanySettingLogic
    {
        internal static bool CompanyControl(TextEdit companyCode, TextEdit companyPeriod, TextEdit firmaNo)
        {
            #region CompanyCode
            if (string.IsNullOrEmpty(companyCode.Text.Trim()))
            {
                XtraMessageBox.Show("Şirket kodu kutusu boş geçilemez", "Hatalı Şirket Kodu Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyCode.Focus();
                return false;
            }
            else if (!companyCode.Text.Trim().All(char.IsDigit))
            {
                XtraMessageBox.Show("Şirket kodu sadece sayısal karakterlerden oluşmalıdır", "Hatalı Şirket Kodu Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyCode.Focus();
                return false;
            }
            else if (companyCode.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Şirket kodu 10 karakterden fazla olamaz", "Hatalı Şirket Kodu Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyCode.Focus();
                return false;
            }
            #endregion

            #region CompanyPeriod
            if (string.IsNullOrEmpty(companyPeriod.Text.Trim()))
            {
                XtraMessageBox.Show("Şirket periyod kutusu boş geçilemez", "Hatalı Şirket Periyod Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyPeriod.Focus();
                return false;
            }
            else if (!companyPeriod.Text.Trim().All(char.IsDigit))
            {
                XtraMessageBox.Show("Şirket periyod sadece sayısal karakterlerden oluşmalıdır", "Hatalı Şirket Periyod Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyPeriod.Focus();
                return false;
            }
            else if (companyPeriod.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Şirket periyod 10 karakterden fazla olamaz", "Hatalı Şirket Periyod Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyPeriod.Focus();
                return false;
            }
            #endregion

            #region FirmaNo
            if (string.IsNullOrEmpty(firmaNo.Text.Trim()))
            {
                XtraMessageBox.Show("Şirket firma no kutusu boş geçilemez", "Hatalı Şirket Firma No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                firmaNo.Focus();
                return false;
            }
            string input = firmaNo.Text.Trim();

            if (input.Count(c => c == '-') > 1 ||
                (input.Contains('-') && !input.StartsWith("-")) ||
                !input.All(c => char.IsDigit(c) || c == '-') ||
                !input.Any(char.IsDigit))
            {
                XtraMessageBox.Show("Şirket firma no sadece rakam ve isteğe bağlı baştaki '-' karakterinden oluşmalı",
                    "Hatalı Şirket Firma No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                firmaNo.Focus();
                return false;
            }
            else if (firmaNo.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Şirket firma no 10 karakterden fazla olamaz", "Hatalı Şirket Firma No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                firmaNo.Focus();
                return false;
            }
            #endregion
            return true;
        }
    }
}