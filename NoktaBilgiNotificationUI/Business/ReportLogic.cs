using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoktaBilgiNotificationUI.Business
{
    internal class ReportLogic
    {
        internal static bool ValidateReportInputs(TextEdit reportName,RichTextBox desc, TimeEdit startTime, NumericUpDown intervalMinutes,
        ComboBoxEdit sendType, CheckEdit[] dayChecks, RichTextBox sqlCommandBox, List<int> selectedPersonIds)
        {
            {
                if (string.IsNullOrWhiteSpace(sqlCommandBox.Text))
                {
                    XtraMessageBox.Show("SQL komutu boş geçilemez.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlCommandBox.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(reportName.Text.Trim()))
                {
                    XtraMessageBox.Show("Rapor Adı Boş Geçilemez.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reportName.Focus();
                    return false;
                }
                if (reportName.Text.Length > 50)
                {
                    XtraMessageBox.Show("Rapor Adı 50 Karakterden Fazla Olamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reportName.Focus();
                    return false;
                }
                if (reportName.Text.Length < 3)
                {
                    XtraMessageBox.Show("Rapor Adı 3 Karakterden Az Olamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reportName.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(desc.Text.Trim()))
                {
                    XtraMessageBox.Show("Rapor Açıklama Boş Geçilemez.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc.Focus();
                    return false;
                }
                if (desc.Text.Length > 100)
                {
                    XtraMessageBox.Show("Rapor Açıklama 100 Karakterden Fazla Olamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc.Focus();
                    return false;
                }
                if (desc.Text.Length < 3)
                {
                    XtraMessageBox.Show("Rapor Açıklama 3 Karakterden Az Olamaz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    desc.Focus();
                    return false;
                }

                if (intervalMinutes.Value < 1 || intervalMinutes.Value > 43829)
                {
                    XtraMessageBox.Show("Çalışma süresi 1 ile 43829 dakika arasında olmalıdır.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intervalMinutes.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(sendType.Text))
                {
                    XtraMessageBox.Show("Gönderim türü seçilmelidir.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sendType.Focus();
                    return false;
                }
                if (!dayChecks.Any(c => c.Checked))
                {
                    XtraMessageBox.Show("En az bir gün seçilmelidir.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dayChecks.First().Focus();
                    return false;
                }    
                string sendTypeText = sendType.Text.Trim().ToLower();
                if ((sendTypeText == "mail" || sendTypeText == "whatsapp") && (selectedPersonIds == null || selectedPersonIds.Count == 0))
                {
                    XtraMessageBox.Show("Gönderim türü Mail veya WhatsApp ise en az bir kişi seçilmelidir.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (startTime.Time.TimeOfDay.TotalMinutes == 0)
                {
                    var result = XtraMessageBox.Show("Başlangıç saati 00:00 olarak ayarlanmış. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        startTime.Focus();
                        return false;
                    }
                }
                return true;
            }
        }
    }
}