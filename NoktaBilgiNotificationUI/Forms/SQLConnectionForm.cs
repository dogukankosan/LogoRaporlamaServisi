using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Classes;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class SQLConnectionForm : XtraForm
    {
        public SQLConnectionForm()
        {
            InitializeComponent();
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            bool statusDB =await SQLCrud.ConnectionStringControlAddAsync(txt_ServerName.Text, txt_UserName.Text, txt_Password.Text, txt_DatabaseName.Text);
            if (statusDB)
            {
                XtraMessageBox.Show("SQL Bağlantı Ayarları Güncelleme İşlemi Başarılı", "Başarılı SQL Bağlantı", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("SQL Bağlantı Ayarları Güncelleme İşlemi Hatalı", "Hatalı SQL Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ServerName.Focus();
            }

        }
        private async void SQLConnectionForm_Load(object sender, EventArgs e)
        {
          bool statusConnection= await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            if (statusConnection)
            {
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
                string[] parameters = EncryptionHelper.Decrypt(dt.Rows[0][0].ToString()).Split(';');
                List<string> resultList = new List<string>();
                foreach (string parameter in parameters)
                {
                    if (!string.IsNullOrEmpty(parameter))
                    {
                        string[] keyValue = parameter.Split('=');
                        string key = keyValue[0].Trim();
                        string value = keyValue.Length > 1 ? keyValue[1].Trim() : string.Empty;
                        if (key == "Server" || key == "Database" || key == "User Id" || key == "Password")
                            resultList.Add(value);
                    }
                }
                txt_ServerName.Text = resultList[0];
                txt_DatabaseName.Text = resultList[1];
                txt_UserName.Text = resultList[2];
                txt_Password.Text = resultList[3];
            }
            txt_ServerName.Focus();
        }

        private void SQLConnectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}