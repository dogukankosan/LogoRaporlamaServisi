using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoktaBilgiNotificationUI.Classes;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class SQLiteCommandForm : XtraForm
    {
        public SQLiteCommandForm()
        {
            InitializeComponent();
        }
        private void SQLiteCommandForm_Load(object sender, EventArgs e)
        {
            UtilityHelper.CustomizeGridView(gridView1);
            richTextBox1.Focus();
        }
        private void encToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string seciliMetin = richTextBox1.SelectedText;
            if (string.IsNullOrWhiteSpace(seciliMetin))
            {
                XtraMessageBox.Show("Lütfen önce metin kutusunda bir metin seçiniz.", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string message = EncryptionHelper.Decrypt(seciliMetin);
                Clipboard.SetText(message);
                XtraMessageBox.Show(message, "Ram bellekte hafızaya alındı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Şifre Çözme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private async void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F5)
            {
                gridView1.Columns.Clear();
                gridControl1.DataSource = null;
                gridControl1.Refresh();
                string seciliMetin = richTextBox1.SelectedText;
                if (string.IsNullOrWhiteSpace(seciliMetin))
                {
                    XtraMessageBox.Show("Lütfen önce metin kutusunda bir metin seçiniz.", "Hatalı Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (richTextBox1.Text.Trim().ToUpper().Contains("SELECT"))
                {
                    gridControl1.DataSource = await SQLiteCrud.GetDataFromSQLiteAsync(seciliMetin);
                    UtilityHelper.CustomizeGridView(gridView1);
                }
                else
                {
                    var values = await SQLiteCrud.InsertUpdateDeleteAsync(richTextBox1.Text);
                    if (values.Success)
                    {
                        XtraMessageBox.Show("Komut Çalıştırma İşlemi Başarılı", "Başarılı Komut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show(values.ErrorMessage, "Hatalı Komut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
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
    }
}