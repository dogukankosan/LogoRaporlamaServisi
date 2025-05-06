using DevExpress.XtraEditors;
using System;
using System.ServiceProcess;
using System.Windows.Forms;
namespace NoktaBilgiNotificationUI.Forms
{
    public partial class HomeForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public HomeForm()
        {
            InitializeComponent();
            Instance = this; 
        }
        internal static HomeForm Instance;
        public string username = "";
        internal void OpenFormInContainer(Form form)
        {
            fluentDesignFormContainer1.Controls.Clear();

            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(form);
                form.Show();
            }
            else
            {
                var homeImg = new HomeImageControl();
                homeImg.Dock = DockStyle.Fill;
                fluentDesignFormContainer1.Controls.Add(homeImg);
            }
        }
        private void btn_SQLForm_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new SQLConnectionForm());
        }
        private void btn_MailSettings_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new EMailSettingsForm());
        }
        private void btn_WhatsappSettings_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new WhatsappSettingsForm());
        }
        private void btn_Thema_Click(object sender, EventArgs e)
        {
            popupMenu2.ShowPopup(Cursor.Position);
        }
        private void HomeForm_Load(object sender, EventArgs e)
        {
            if (username!="admin")
            {
                accordionControlElement1.Visible = false;
            }
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            string savedTheme = Properties.Settings.Default.ThemaName;
            if (!string.IsNullOrEmpty(savedTheme))
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(savedTheme);
            }
            DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            var homeImg = new HomeImageControl();
            homeImg.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(homeImg);
        }
        private void Default_StyleChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ThemaName = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName;
            Properties.Settings.Default.Save();
        }
        private void btn_ReportForm_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new ReportForm());
        }

        private void btn_SendPerson_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new SendPersonForm());
        }

        private void btn_SQLITEForm_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new SQLiteCommandForm());
        }

        private void btn_softwareLog_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new SoftwareLogForm());
        }

        private void btn_userSettings_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new UserSettingsForm());
        }
        private void btn_StartService_Click(object sender, EventArgs e)
        {
            try
            {
                using (ServiceController sc = new ServiceController("NoktaBilgilendirmeService"))
                {
                    if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.Paused)
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                        XtraMessageBox.Show("Servis Başlatıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Servis zaten çalışıyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Servis başlatılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btn_StopService_Click(object sender, EventArgs e)
        {
            try
            {
                using (ServiceController sc = new ServiceController("NoktaBilgilendirmeService"))
                {
                    if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.StartPending)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                        XtraMessageBox.Show("Servis Durduruldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Servis zaten durdurulmuş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Servis durdurulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_MailSettings_Click_1(object sender, EventArgs e)
        {
            OpenFormInContainer(new EMailSettingsForm());
        }

        private void btn_WebService_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new WebServiceSettingsForm());
        }

        private void btn_sendCount_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new MailAndWpCountForm());
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_MailError_Click(object sender, EventArgs e)
        {
            OpenFormInContainer(new ErrorMailForm());
        }
    }
}