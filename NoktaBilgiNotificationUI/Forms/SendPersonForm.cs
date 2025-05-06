using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Business;
using NoktaBilgiNotificationUI.Classes;
using ExcelDataReader;
using System.Drawing;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class SendPersonForm : XtraForm
    {
        public SendPersonForm()
        {
            InitializeComponent();
        }
        private int id = -1;
        private void Clear()
        {
            txt_Mail.Text = "";
            msk_WPNo.Text = "";
            txt_PersonName.Text = "";
            id = -1;
            chk_Status.Checked = false;
            btn_Save.Text = "Kaydet";
        }
        private async void List()
        {
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync(@"
SELECT 
    ID,
    NameSurname AS 'Yetkili Adı',
    MailAdress AS 'Mail Adres',
    PhoneNumber AS 'Telefon',
    CASE WHEN Status_ = 1 THEN 'Aktif' ELSE 'Pasif' END AS 'Durum'
FROM SendPerson
");

            gridControl1.DataSource = dt;
            UtilityHelper.CustomizeGridView(gridView1);
        }
        private void SendPersonForm_Load(object sender, EventArgs e)
        {
            List();
            txt_PersonName.Focus();
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (SendPersonLogic.ValidatePersonInputs(txt_PersonName, msk_WPNo, txt_Mail))
            {
                if (id != -1)
                {
                    var status = await SQLiteCrud.InsertUpdateDeleteAsync(
$@"UPDATE SendPerson 
   SET MailAdress = '{txt_Mail.Text.Trim()}', 
       PhoneNumber = '{msk_WPNo.Text.Trim()}', 
       NameSurname = '{txt_PersonName.Text.Trim()}',
       Status_ = {(chk_Status.Checked ? 1 : 0)}
   WHERE ID = {id}");

                    if (status.Success)
                    {
                        XtraMessageBox.Show("Personel Güncelleme İşlemi Başarılı", "Başarılı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        List();
                    }
                    else
                    {
                        XtraMessageBox.Show(status.ErrorMessage, "Hatalı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    var status = await SQLiteCrud.InsertUpdateDeleteAsync($"INSERT INTO SendPerson (MailAdress, PhoneNumber, NameSurname, Status_) VALUES('{txt_Mail.Text.Trim()}', '{msk_WPNo.Text.Trim()}', '{txt_PersonName.Text.Trim()}', {(chk_Status.Checked ? 1 : 0)})");
                    if (status.Success)
                    {
                        XtraMessageBox.Show("Personel Ekleme İşlemi Başarılı", "Başarılı Ekleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        List();
                    }
                    else
                    {
                        XtraMessageBox.Show(status.ErrorMessage, "Hatalı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                try
                {
                    id = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "ID"));
                }
                catch (Exception)
                {
                    return;
                }      
                txt_PersonName.Text = Convert.ToString(gridView1.GetRowCellValue(e.RowHandle, "Yetkili Adı"));
                msk_WPNo.Text = Convert.ToString(gridView1.GetRowCellValue(e.RowHandle, "Telefon"));
                txt_Mail.Text = Convert.ToString(gridView1.GetRowCellValue(e.RowHandle, "Mail Adres"));
                chk_Status.Checked = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString() == "Aktif";
                btn_Save.Text = "Güncelle";
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Durum" && e.CellValue != null && e.CellValue != DBNull.Value)
            {
                string durum = e.CellValue.ToString().Trim().ToLower();
                if (durum == "aktif")
                    e.Appearance.ForeColor = Color.Green;
                else if (durum == "pasif")
                    e.Appearance.ForeColor = Color.Red;
            }
        }
    }
}