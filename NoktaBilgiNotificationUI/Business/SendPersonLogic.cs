using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NoktaBilgiNotificationUI.Business
{
    internal class SendPersonLogic
    {
        internal static bool ValidatePersonInputs(TextEdit name, MaskedTextBox phone, TextEdit mail)
        {
            #region Yetkili Adı
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                XtraMessageBox.Show("Yetkili adı boş bırakılamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                name.Focus();
                return false;
            }
            else if (name.Text.Trim().Length > 50)
            {
                XtraMessageBox.Show("Yetkili adı 50 karakterden fazla olamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                name.Focus();
                return false;
            }
            #endregion
            #region Telefon
            string phoneInput = phone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phoneInput))
            {
                XtraMessageBox.Show("Telefon numarası boş bırakılamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Focus();
                return false;
            }
            else if (!Regex.IsMatch(phoneInput, @"^\+?\d{10,15}$"))
            {
                XtraMessageBox.Show("Telefon numarası geçerli bir formatta olmalıdır. Örnek: +905551112233", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Focus();
                return false;
            }
            else if (phoneInput.Length != 13)
            {
                XtraMessageBox.Show("Telefon numarası kutusu 13 karakter olmalıdır (+901234567890)", "Hatalı Telefon No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Focus();
                return false;
            }
            else if (!phoneInput.StartsWith("+90"))
            {
                XtraMessageBox.Show("Telefon numarası +90 bile başlamalıdır (+901234567890)", "Hatalı Telefon No Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Focus();
                return false;
            }
            #endregion
            #region Mail
            string mailInput = mail.Text.Trim();
            if (string.IsNullOrWhiteSpace(mailInput))
            {
                XtraMessageBox.Show("Mail adresi boş bırakılamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return false;
            }
            else if (!Regex.IsMatch(mailInput, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                XtraMessageBox.Show("Geçerli bir mail adresi giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return false;
            }
            #endregion
            return true;
        }
    }
}