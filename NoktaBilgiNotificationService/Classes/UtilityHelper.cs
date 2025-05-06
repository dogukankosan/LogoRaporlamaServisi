using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace NoktaBilgiNotificationService.Classes
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