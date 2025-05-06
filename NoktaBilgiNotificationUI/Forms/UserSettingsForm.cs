using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Classes;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class UserSettingsForm : XtraForm
    {
        public UserSettingsForm()
        {
            InitializeComponent();
        }
        private async void UserSettingsForm_Load(object sender, EventArgs e)
        {
            bool companySettingsStatus = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM AdminLogin LIMIT 1");
            if (!companySettingsStatus)
                return;
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM AdminLogin WHERE UserName!='admin' ");
            txt_UserName.Text = dt.Rows[0]["UserName"].ToString();
            txt_Password.Text = EncryptionHelper.Decrypt(dt.Rows[0]["UserPassword"].ToString());
            txt_UserName.Focus();
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Password.Text.Trim()) || string.IsNullOrEmpty(txt_UserName.Text.Trim()))
            {
                XtraMessageBox.Show("Kullanıcı Adı Veya Şifre Boş Geçilemez", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UserName.Focus();
                return;
            }
            if (txt_UserName.Text.Trim()=="admin")
            {
                XtraMessageBox.Show("Kullanıcı Adı admin Olamaz", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UserName.Focus();
                return;
            }
            var values=await SQLiteCrud.InsertUpdateDeleteAsync("UPDATE AdminLogin SET UserName='"+txt_UserName.Text.Trim()+ "' , UserPassword='"+EncryptionHelper.Encrypt(txt_Password.Text.Trim())+ "' WHERE UserName!='admin'");
            if (values.Success)
            {
                XtraMessageBox.Show("Güncelleme İşlemi Başarılı", "Başarılı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else 
            {
                XtraMessageBox.Show(values.ErrorMessage, "Hatalı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UserName.Focus();
            }
        }

        private void UserSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}