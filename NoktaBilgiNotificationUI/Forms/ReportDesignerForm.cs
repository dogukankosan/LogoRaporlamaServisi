using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Classes;
using NoktaBilgiNotificationUI.Business;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class ReportDesignerForm : XtraForm
    {
        public ReportDesignerForm()
        {
            InitializeComponent();
        }
        internal int id = -1;
        private async void PersonGrid(string selectedIdsCsv = "")
        {
            popupContainerControl1.Size = new Size(500, 300);
            popupPersonSelector.Properties.PopupControl = popupContainerControl1;
            popupPersonSelector.Properties.ShowPopupCloseButton = true;
            popupPersonSelector.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync(@"
        SELECT ID, NameSurname AS 'Yetkili', PhoneNumber AS 'Telefon', MailAdress AS 'Mail' FROM SendPerson WHERE Status_=1
    ");
            dt.Columns.Add("Secim", typeof(bool));
            List<string> selectedIds = selectedIdsCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (DataRow row in dt.Rows)
            {
                string id = row["ID"].ToString();
                row["Secim"] = selectedIds.Contains(id);
            }
            gridControlPerson.DataSource = dt;
            gridControlPerson.MainView = gridViewPerson;
            gridViewPerson.PopulateColumns();
            foreach (GridColumn col in gridViewPerson.Columns)
            {
                if (col.FieldName == "Secim")
                {
                    col.Caption = "Seçim";
                    col.Width = 30;
                    col.VisibleIndex = 0;
                    col.OptionsColumn.AllowEdit = true;
                    col.OptionsColumn.AllowFocus = true;
                }
                else
                {
                    col.OptionsColumn.AllowEdit = false;
                    col.OptionsColumn.AllowFocus = false;
                }
            }
            gridViewPerson.OptionsView.ShowGroupPanel = false;
        }
        private void ReportDesignerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private async void ReportDesignerForm_Load(object sender, EventArgs e)
        {
            PersonGrid();
            if (id != -1 && (this.Text.Contains("Güncelle")))
            {
                bool dtWp = await UtilityHelper.IsDataExistsSQLite("SELECT * FROM SchedulerTasksReport WHERE Id=" + id + " LIMIT 1");
                if (!dtWp)
                {
                    XtraMessageBox.Show("Seçilen Rapor Bulunamadı", "Hatalı Rapor Seçme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT * FROM SchedulerTasksReport WHERE Id=" + id + " LIMIT 1");
                string personListRaw = dt.Rows[0]["SendPersonList"]?.ToString();
                string selectedPersonList = personListRaw ?? "";
                PersonGrid(selectedPersonList);
                txt_ReportName.Text = dt.Rows[0]["TaskName"].ToString();
                if (DateTime.TryParse(dt.Rows[0]["StartTime"].ToString(), out DateTime startTime))
                    txt_StartTime.EditValue = startTime;
                if (decimal.TryParse(dt.Rows[0]["RepeatEveryMinutes"].ToString(), out decimal repeatValue))
                    nmr_Repeat.Value = repeatValue;
                chk_IsActive.Checked = Convert.ToInt32(dt.Rows[0]["IsActive"]) == 1;
                cmb_SendType.Text = dt.Rows[0]["SendType"].ToString();
                richTextBox1.Text = EncryptionHelper.Decrypt(dt.Rows[0]["CommandPayload"].ToString());
                rch_Desc.Text = dt.Rows[0]["TaskDesc"].ToString();
                string daysValue = dt.Rows[0]["Days"].ToString();
                string[] selectedDays = daysValue.Split(',');
                foreach (var day in selectedDays)
                {
                    switch (day.Trim())
                    {
                        case "Mon": chk_Monday.Checked = true; break;
                        case "Tue": chk_Tuesday.Checked = true; break;
                        case "Wed": chk_Wednesday.Checked = true; break;
                        case "Thu": chk_Thursday.Checked = true; break;
                        case "Fri": chk_Friday.Checked = true; break;
                        case "Sat": chk_Saturday.Checked = true; break;
                        case "Sun": chk_Sunday.Checked = true; break;
                    }
                }
            }
            txt_ReportName.Focus();
            cmb_SendType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            txt_StartTime.Properties.EditMask = "HH:mm";
            txt_StartTime.Properties.DisplayFormat.FormatString = "HH:mm";
            txt_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            txt_StartTime.Properties.Mask.UseMaskAsDisplayFormat = true;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = richTextBox1.SelectionStart;
            int selectionLength = richTextBox1.SelectionLength;
            richTextBox1.SuspendLayout();
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            string[] keywords = {
    "SELECT", "FROM", "WHERE", "INSERT", "INTO", "VALUES", "UPDATE", "SET", "DELETE",
    "JOIN", "INNER", "LEFT", "RIGHT", "FULL", "CROSS", "ON", "AS", "DISTINCT", "GROUP", "BY",
    "ORDER", "HAVING", "TOP", "LIMIT", "OFFSET", "IN", "IS", "NOT", "NULL", "AND", "OR",
    "LIKE", "EXISTS", "CASE", "WHEN", "THEN", "ELSE", "END", "BETWEEN", "UNION", "ALL", "ANY",
    "WITH", "NOLOCK", "CREATE", "TABLE", "ALTER", "DROP", "TRUNCATE", "INDEX", "PRIMARY",
    "KEY", "FOREIGN", "REFERENCES", "DEFAULT", "CHECK", "VIEW", "PROCEDURE", "FUNCTION",
    "BEGIN", "END", "DECLARE", "IF", "ELSE", "WHILE", "TRY", "CATCH", "TRANSACTION", "COMMIT",
    "ROLLBACK", "USE", "GO", "EXEC", "PRINT", "OUTER", "DESC", "ASC", "INTO", "OVER", "PARTITION", "ROWNUM"
};
            foreach (var keyword in keywords)
            {
                var matches = System.Text.RegularExpressions.Regex.Matches(
                    richTextBox1.Text, $@"\b{keyword}\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    richTextBox1.Select(match.Index, match.Length);
                    richTextBox1.SelectionColor = Color.Blue;
                }
            }
            string[] functions = {
    "COUNT", "SUM", "AVG", "MIN", "MAX", "GETDATE", "SYSDATETIME", "CURRENT_TIMESTAMP", "DATEADD", "DATEDIFF",
    "DATENAME", "DATEPART", "ISNULL", "NULLIF", "COALESCE", "CAST", "CONVERT", "TRY_CAST", "TRY_CONVERT",
    "LEN", "LEFT", "RIGHT", "CHARINDEX", "SUBSTRING", "REPLACE", "RTRIM", "LTRIM", "UPPER", "LOWER",
    "ABS", "ROUND", "CEILING", "FLOOR", "POWER", "SQUARE", "EXP", "LOG", "LOG10", "NEWID", "ROW_NUMBER",
    "RANK", "DENSE_RANK", "NTILE", "LEAD", "LAG", "FORMAT", "GETUTCDATE", "HOST_NAME", "SUSER_NAME",
    "SCOPE_IDENTITY", "IDENT_CURRENT", "IDENT_INCR", "IDENT_SEED", "OBJECT_ID", "OBJECT_NAME",
    "DB_NAME", "DB_ID", "YEAR", "MONTH", "DAY", "GETDATE", "EOMONTH"
};
            foreach (var func in functions)
            {
                var matches = System.Text.RegularExpressions.Regex.Matches(
                    richTextBox1.Text, $@"\b{func}\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    richTextBox1.Select(match.Index, match.Length);
                    richTextBox1.SelectionColor = Color.Purple;
                }
            }
            richTextBox1.Select(selectionStart, selectionLength);
            richTextBox1.ResumeLayout();
        }
        private async Task<(bool isValid, string errorMessage, int errorLine)> IsSqlSyntaxValid(string sql)
        {
            try
            {
                bool SQLConnectStatus = await UtilityHelper.IsDataExistsSQLite("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
                if (!SQLConnectStatus)
                {
                    XtraMessageBox.Show("Önce SQL Bağlantı Ayarlarını Tamamlayınız", "SQL Bağlantı Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false, "SQL bağlantısı eksik.", -1);
                }
                DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
                string sqlConnStr = EncryptionHelper.Decrypt(dt.Rows[0]["SQLConnectString"].ToString());
                using (var conn = new SqlConnection(sqlConnStr))
                {
                    await conn.OpenAsync();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SET PARSEONLY ON; " + sql;
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return (true, null, -1);
            }
            catch (SqlException ex)
            {
                int errorLine = -1;
                var match = System.Text.RegularExpressions.Regex.Match(ex.Message, @"Line (\d+)");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int line))
                    errorLine = line;
                return (false, ex.Message, errorLine);
            }
        }
        internal static async Task<bool> ControlLoadDataIntoGridViewAsync(string query, string connection)
        {
            using (SqlConnection conn = new SqlConnection(EncryptionHelper.Decrypt(connection)))
            {
                try
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        try
                        {
                            cmd.CommandTimeout = 300;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message, "Hatalı SQL İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show(e.Message, "Hatalı SQL İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            var result = await IsSqlSyntaxValid(richTextBox1.Text);
            if (!result.isValid)
            {
                richTextBox1.BackColor = Color.MistyRose;
                if (result.errorLine > 0)
                {
                    XtraMessageBox.Show($"SQL Syntax Hatası:\n{result.errorMessage}\nSatır: {result.errorLine}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    XtraMessageBox.Show("SQL Syntax Hatası:\n" + result.errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
                richTextBox1.BackColor = Color.White;
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync("SELECT SQLConnectString FROM SqlConnectionString LIMIT 1");
            bool dtValuesControl = await ControlLoadDataIntoGridViewAsync(richTextBox1.Text.Trim(), dt.Rows[0]["SQLConnectString"].ToString());
            if (!dtValuesControl)
            {
                return;
            }
            DataTable gridData = gridControlPerson.DataSource as DataTable;
            List<string> selectedIds = new List<string>();
            if (gridData != null)
            {
                foreach (DataRow row in gridData.Rows)
                {
                    if (row["Secim"] != DBNull.Value && Convert.ToBoolean(row["Secim"]) == true)
                    {
                        selectedIds.Add(row["ID"].ToString());
                    }
                }
            }
            List<int> selectedPersonIds = new List<int>();
            if (gridData != null)
            {
                selectedPersonIds = gridData.AsEnumerable()
                    .Where(r => r["Secim"] != DBNull.Value && Convert.ToBoolean(r["Secim"]))
                    .Select(r => Convert.ToInt32(r["ID"]))
                    .ToList();
            }
            bool statusLogic = ReportLogic.ValidateReportInputs(
                txt_ReportName,
                rch_Desc,
                txt_StartTime,
                nmr_Repeat,
                cmb_SendType,
                new CheckEdit[]
                {
        chk_Monday, chk_Tuesday, chk_Wednesday,
        chk_Thursday, chk_Friday, chk_Saturday, chk_Sunday
                },
                richTextBox1,
                selectedPersonIds
            );

            if (!statusLogic)
                return;
            string sendPersonList = string.Join(",", selectedIds);
            string daysSelected = string.Join(",", new List<string> {
    chk_Monday.Checked ? "Mon" : "",
    chk_Tuesday.Checked ? "Tue" : "",
    chk_Wednesday.Checked ? "Wed" : "",
    chk_Thursday.Checked ? "Thu" : "",
    chk_Friday.Checked ? "Fri" : "",
    chk_Saturday.Checked ? "Sat" : "",
    chk_Sunday.Checked ? "Sun" : ""
}.Where(x => !string.IsNullOrEmpty(x)));
            if (this.Text.Contains("Ekle"))
            {
                string query = $@"
INSERT INTO SchedulerTasksReport (
    TaskName,
    TaskDesc,
    IsActive,
    StartTime,
    RepeatEveryMinutes,
    Days,
    SendType,
    CommandPayload,
    SendPersonList
)
VALUES (
    '{txt_ReportName.Text.Trim()}',
    '{rch_Desc.Text.Trim()}',
    {(chk_IsActive.Checked ? 1 : 0)},
    '{txt_StartTime.Text.Trim()}',
    {nmr_Repeat.Value},
    '{daysSelected}',
    '{cmb_SendType.Text.Trim()}',
    '{EncryptionHelper.Encrypt(richTextBox1.Text.Trim())}',
    '{sendPersonList}'
);";

                var status = await SQLiteCrud.InsertUpdateDeleteAsync(query);
                if (status.Success)
                {
                    XtraMessageBox.Show("Raporu Kaydetme İşlemi Başarılı", "Başarılı Rapor Kaydetme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); this.Close();
                }
                else
                {
                    XtraMessageBox.Show(status.ErrorMessage, "Hatalı SQLite İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox1.Focus();
                    return;
                }
            }
            if (this.Text.Contains("Güncelle"))
            {
                string query = $@"
UPDATE SchedulerTasksReport
SET 
    TaskName = '{txt_ReportName.Text.Trim()}',
    TaskDesc='{rch_Desc.Text.Trim()}',
    IsActive = {(chk_IsActive.Checked ? 1 : 0)},
    StartTime = '{txt_StartTime.Text.Trim()}',
    RepeatEveryMinutes = {nmr_Repeat.Value},
    Days = '{daysSelected}',
    SendType = '{cmb_SendType.Text.Trim()}',
    LastRun=NULL,
    CommandPayload = '{EncryptionHelper.Encrypt(richTextBox1.Text.Trim())}',
    SendPersonList = '{sendPersonList}'
WHERE 
    Id = {id};";

                var status = await SQLiteCrud.InsertUpdateDeleteAsync(query);
                if (status.Success)
                {
                    XtraMessageBox.Show("Raporu Güncelleme İşlemi Başarılı", "Başarılı Rapor Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(status.ErrorMessage, "Hatalı SQLite İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox1.Focus();
                    return;
                }
            }
        }
        private void popupPersonSelector_Click(object sender, EventArgs e)
        {
            popupPersonSelector.ShowPopup();
        }
        private void gridViewPerson_ShownEditor(object sender, EventArgs e)
        {
            if (gridViewPerson.FocusedColumn.FieldName == "Secim")
            {
                CheckEdit edit = gridViewPerson.ActiveEditor as CheckEdit;
                if (edit != null)
                {
                    edit.CheckedChanged += (s, ev) =>
                    {
                        gridViewPerson.PostEditor();
                        gridViewPerson.UpdateCurrentRow();
                    };
                }
            }
        }
    }
}