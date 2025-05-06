using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Drawing.Imaging;

namespace NoktaBilgiNotificationUI.Classes
{
   internal class UtilityHelper
    {
        internal static async Task<bool> IsDataExistsSQLite(string query)
        {
            DataTable dt = await SQLiteCrud.GetDataFromSQLiteAsync(query);
            if (dt == null || dt.Rows.Count == 0)
                return false;
            if (string.IsNullOrEmpty(dt.Rows[0][0]?.ToString()))
                return false;
            return true;
        }
        internal static string ImageToBase64(Image image, ImageFormat format)
        {
            if (image == null)
                return null;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging("ImageToBase64 Error: " + ex.Message + " --- " + ex.ToString());
                return null;
            }
        }
        internal static Image Base64ToImage(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return null;
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms, true);
                }
            }
            catch (Exception ex)
            {
                TextLog.TextLogging("Base64ToImage Error: " + ex.Message + " --- " + ex.ToString());
                return null;
            }
        }
        public static void CustomizeGridView(GridView gridView)
        {
            if (gridView == null) return;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsBehavior.ReadOnly = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.RowAutoHeight = true;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.OptionsFind.AlwaysVisible = true;
            gridView.OptionsFind.FindNullPrompt = "Aramak için buraya yazın...";
            gridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            gridView.RowHeight = 28;
            gridView.Appearance.Row.Font = new Font("Segoe UI", 9);
            gridView.Appearance.Row.Options.UseFont = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(245, 245, 245);
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.OddRow.BackColor = Color.White;
            gridView.Appearance.OddRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(200, 230, 250);
            gridView.Appearance.FocusedRow.ForeColor = Color.Black;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(60, 120, 200);
            gridView.Appearance.HeaderPanel.ForeColor = Color.White;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.GridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            gridView.GridControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            int totalColumns = gridView.Columns.Count;
            if (totalColumns > 0)
            {
                int gridWidth = gridView.GridControl.Width - 40; 
                int columnWidth = gridWidth / totalColumns;
                foreach (GridColumn column in gridView.Columns)
                {
                    column.MinWidth = 120;
                    column.Width = Math.Max(columnWidth, 120);
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
            }
        }
        public static byte[] ExportToExcelBytes(DataTable dt)
        {
            using (var wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "Rapor");
                ws.Columns().AdjustToContents();
                using (var ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}