using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Classes;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class MailAndWpCountForm : XtraForm
    {
        public MailAndWpCountForm()
        {
            InitializeComponent();
        }
        private async void MailAndWpCountForm_Load(object sender, EventArgs e)
        {
            bool dataCheckRemote=await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString,WebToken,WebPassword FROM WebSettings LIMIT 1");
            if (!dataCheckRemote)
            {
                XtraMessageBox.Show("Web SQL Bağlantı Ayarları Listeleme Hatalı Önce Web Servis Ayarlarınızı Giriniz", "Hatalı Web SQL Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            DataTable remoteSQL = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString,WebToken,WebPassword FROM WebSettings LIMIT 1");
            nmr_wp.Focus();
            DataTable dt = await SQLCrud.LoadDataIntoGridViewAsync("SELECT * FROM CustomersNotification WITH (NOLOCK) WHERE CustomerToken='" + remoteSQL.Rows[0]["WebToken"].ToString() + "' AND CustomerPassword='" + remoteSQL.Rows[0]["WebPassword"].ToString() + "'", remoteSQL.Rows[0][0].ToString());
            if (dt is null || dt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Lütfen Önce Web Servis Ayarlarınızı Giriniz", "Hatalı Veritabanı İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (!(dt is null))
            {
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        object wpCountObj = dt.Rows[0]["WpCount"];
                        if (wpCountObj != DBNull.Value && !string.IsNullOrWhiteSpace(wpCountObj.ToString()))
                        {
                            string decryptedWp = EncryptionHelper.Decrypt(wpCountObj.ToString());
                            nmr_wp.Value = int.TryParse(decryptedWp, out int wpVal) ? wpVal : 0;
                        }
                        else
                            nmr_wp.Value = 0;
                        object mailCountObj = dt.Rows[0]["MailCount"];
                        if (mailCountObj != DBNull.Value && !string.IsNullOrWhiteSpace(mailCountObj.ToString()))
                        {
                            string decryptedMail = EncryptionHelper.Decrypt(mailCountObj.ToString());
                            nmr_mail.Value = int.TryParse(decryptedMail, out int mailVal) ? mailVal : 0;
                        }
                        else
                            nmr_mail.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Hatalı Veritabanı Okuma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextLog.TextLogging(ex.Message + " -- " + ex.ToString());
                        return;
                    }
                }
            }
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {       
            bool dataCheckRemote = await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString,WebToken,WebPassword FROM WebSettings LIMIT 1");
            if (!dataCheckRemote)
            {
                XtraMessageBox.Show("Web SQL Bağlantı Ayarları Listeleme Hatalı Önce Web Servis Ayarlarınızı Giriniz", "Hatalı Web SQL Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            DataTable remoteSQL =await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString,WebToken,WebPassword FROM WebSettings LIMIT 1");
            DataTable dt = await SQLCrud.LoadDataIntoGridViewAsync("SELECT * FROM CustomersNotification WITH (NOLOCK) WHERE CustomerToken='" + remoteSQL.Rows[0]["WebToken"].ToString() + "' AND CustomerPassword='" + remoteSQL.Rows[0]["WebPassword"].ToString() + "'", remoteSQL.Rows[0][0].ToString());
            if (dt is null || dt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Lütfen Önce Web Servis Ayarlarınızı Giriniz", "Hatalı Veritabanı İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(dt.Rows[0]["ID"].ToString()))
                {
                    XtraMessageBox.Show("Lütfen Önce Web Servis Ayarlarınızı Giriniz", "Hatalı Veritabanı İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Veritabanı İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool status=await SQLCrud.InserUpdateDelete("UPDATE CustomersNotification SET WpCount='" + EncryptionHelper.Encrypt(nmr_wp.Value.ToString()) + "', MailCount='" + EncryptionHelper.Encrypt(nmr_mail.Value.ToString()) + "',WpStartCount='" + EncryptionHelper.Encrypt(nmr_wp.Value.ToString()) + "' ,MailStartCount='" + EncryptionHelper.Encrypt(nmr_mail.Value.ToString()) + "' WHERE ID=" + dt.Rows[0][0].ToString() + "", remoteSQL.Rows[0][0].ToString());
            if (status)
            {
                XtraMessageBox.Show("Gönderim Sayısı Güncelleme İşlemi Başarılı", "Başarılı Gönderim Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextLog.TextLogging("Kontör Sayısı Formunda Whatsapp Veya Mail de Bir Kontör Güncellemesi Yapıldı", "1");
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Gönderim Sayısı Güncelleme İşlemi Hatalı", "Hatalı Gönderim Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void MailAndWpCountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm.Instance.OpenFormInContainer(null);
        }
    }
}