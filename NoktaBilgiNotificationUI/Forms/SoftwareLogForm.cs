using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using NoktaBilgiNotificationUI.Classes;

namespace NoktaBilgiNotificationUI.Forms
{
    public partial class SoftwareLogForm : XtraForm
    {
        public SoftwareLogForm()
        {
            InitializeComponent();
        }
        private class LogItem
        {
            public string UILog { get; set; }
            public string ServiceLog { get; set; }
        }
        private List<LogItem> ReadLogs()
        {
            string uiPath = Path.Combine(Application.StartupPath, "Logs", "UILog.txt");
            string servicePath = Path.Combine(Application.StartupPath, "Logs", "ServiceLog.txt");
            var uiLines = File.Exists(uiPath) ? File.ReadAllLines(uiPath) : new string[0];
            var serviceLines = File.Exists(servicePath) ? File.ReadAllLines(servicePath) : new string[0];
            int maxLineCount = Math.Max(uiLines.Length, serviceLines.Length);
            var list = new List<LogItem>();
            for (int i = 0; i < maxLineCount; i++)
            {
                list.Add(new LogItem
                {
                    UILog = i < uiLines.Length ? uiLines[i] : "",
                    ServiceLog = i < serviceLines.Length ? serviceLines[i] : ""
                });
            }
            return list;
        }
        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
            saveDialog.Title = "Excel'e Aktar";
            saveDialog.FileName = "UILog.xlsx";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                gridView1.OptionsPrint.PrintDetails = true;
                gridControl1.ExportToXlsx(saveDialog.FileName);
                XtraMessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SoftwareLogForm_Load(object sender, EventArgs e)
        {    
            gridControl1.DataSource = ReadLogs();
            UtilityHelper.CustomizeGridView(gridView1);
        }
    }
}