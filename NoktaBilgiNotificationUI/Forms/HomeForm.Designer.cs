namespace NoktaBilgiNotificationUI.Forms
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_SQLForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_WhatsappSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_SQLITEForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_softwareLog = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_StartService = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_StopService = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_WebService = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_sendCount = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_ReportForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_SendPerson = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_userSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_MailSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btn_Thema = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.skinPaletteDropDownButtonItem1 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.skinPaletteDropDownButtonItem2 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.skinBarSubItem2 = new DevExpress.XtraBars.SkinBarSubItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btn_MailError = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(260, 31);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(842, 442);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3,
            this.btn_Thema});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 442);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btn_SQLForm,
            this.btn_WhatsappSettings,
            this.btn_SQLITEForm,
            this.btn_softwareLog,
            this.btn_StartService,
            this.btn_StopService,
            this.btn_WebService,
            this.btn_sendCount,
            this.btn_MailError});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Admin Ayarlar";
            // 
            // btn_SQLForm
            // 
            this.btn_SQLForm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SQLForm.ImageOptions.Image")));
            this.btn_SQLForm.Name = "btn_SQLForm";
            this.btn_SQLForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_SQLForm.Text = "SQL Bağlantı Ayarları";
            this.btn_SQLForm.Click += new System.EventHandler(this.btn_SQLForm_Click);
            // 
            // btn_WhatsappSettings
            // 
            this.btn_WhatsappSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_WhatsappSettings.ImageOptions.Image")));
            this.btn_WhatsappSettings.Name = "btn_WhatsappSettings";
            this.btn_WhatsappSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_WhatsappSettings.Text = "Whatsapp Ayarları";
            this.btn_WhatsappSettings.Click += new System.EventHandler(this.btn_WhatsappSettings_Click);
            // 
            // btn_SQLITEForm
            // 
            this.btn_SQLITEForm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SQLITEForm.ImageOptions.Image")));
            this.btn_SQLITEForm.Name = "btn_SQLITEForm";
            this.btn_SQLITEForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_SQLITEForm.Text = "SQLITE Komut";
            this.btn_SQLITEForm.Click += new System.EventHandler(this.btn_SQLITEForm_Click);
            // 
            // btn_softwareLog
            // 
            this.btn_softwareLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_softwareLog.ImageOptions.Image")));
            this.btn_softwareLog.Name = "btn_softwareLog";
            this.btn_softwareLog.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_softwareLog.Text = "Yazılım Hata Log";
            this.btn_softwareLog.Click += new System.EventHandler(this.btn_softwareLog_Click);
            // 
            // btn_StartService
            // 
            this.btn_StartService.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_StartService.ImageOptions.Image")));
            this.btn_StartService.Name = "btn_StartService";
            this.btn_StartService.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_StartService.Text = "Servisi Çalıştır";
            this.btn_StartService.Click += new System.EventHandler(this.btn_StartService_Click);
            // 
            // btn_StopService
            // 
            this.btn_StopService.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_StopService.ImageOptions.Image")));
            this.btn_StopService.Name = "btn_StopService";
            this.btn_StopService.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_StopService.Text = "Servisi Durdur";
            this.btn_StopService.Click += new System.EventHandler(this.btn_StopService_Click);
            // 
            // btn_WebService
            // 
            this.btn_WebService.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_WebService.ImageOptions.Image")));
            this.btn_WebService.Name = "btn_WebService";
            this.btn_WebService.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_WebService.Text = "Web Service Ayarları";
            this.btn_WebService.Click += new System.EventHandler(this.btn_WebService_Click);
            // 
            // btn_sendCount
            // 
            this.btn_sendCount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_sendCount.ImageOptions.Image")));
            this.btn_sendCount.Name = "btn_sendCount";
            this.btn_sendCount.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_sendCount.Text = "Mail Whatsapp Gönderim Sayısı";
            this.btn_sendCount.Click += new System.EventHandler(this.btn_sendCount_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btn_ReportForm,
            this.btn_SendPerson});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Raporlar";
            // 
            // btn_ReportForm
            // 
            this.btn_ReportForm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ReportForm.ImageOptions.Image")));
            this.btn_ReportForm.Name = "btn_ReportForm";
            this.btn_ReportForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_ReportForm.Text = "Rapor";
            this.btn_ReportForm.Click += new System.EventHandler(this.btn_ReportForm_Click);
            // 
            // btn_SendPerson
            // 
            this.btn_SendPerson.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SendPerson.ImageOptions.Image")));
            this.btn_SendPerson.Name = "btn_SendPerson";
            this.btn_SendPerson.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_SendPerson.Text = "Gönderilecek Kişiler";
            this.btn_SendPerson.Click += new System.EventHandler(this.btn_SendPerson_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btn_userSettings,
            this.btn_MailSettings});
            this.accordionControlElement3.Expanded = true;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Kullanıcı Ayarları";
            // 
            // btn_userSettings
            // 
            this.btn_userSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_userSettings.ImageOptions.Image")));
            this.btn_userSettings.Name = "btn_userSettings";
            this.btn_userSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_userSettings.Text = "Kullanıcı Giriş";
            this.btn_userSettings.Click += new System.EventHandler(this.btn_userSettings_Click);
            // 
            // btn_MailSettings
            // 
            this.btn_MailSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_MailSettings.ImageOptions.Image")));
            this.btn_MailSettings.Name = "btn_MailSettings";
            this.btn_MailSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_MailSettings.Text = "EMail Ayarları";
            this.btn_MailSettings.Click += new System.EventHandler(this.btn_MailSettings_Click_1);
            // 
            // btn_Thema
            // 
            this.btn_Thema.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thema.ImageOptions.Image")));
            this.btn_Thema.Name = "btn_Thema";
            this.btn_Thema.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_Thema.Text = "Tema";
            this.btn_Thema.Click += new System.EventHandler(this.btn_Thema_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinPaletteDropDownButtonItem1,
            this.skinBarSubItem1,
            this.skinPaletteDropDownButtonItem2,
            this.skinBarSubItem2});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1102, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // skinPaletteDropDownButtonItem1
            // 
            this.skinPaletteDropDownButtonItem1.Id = 0;
            this.skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "Temalar";
            this.skinBarSubItem1.Id = 1;
            this.skinBarSubItem1.ItemClickFireMode = DevExpress.XtraBars.BarItemEventFireMode.Immediate;
            this.skinBarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText;
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            this.skinBarSubItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // skinPaletteDropDownButtonItem2
            // 
            this.skinPaletteDropDownButtonItem2.Id = 2;
            this.skinPaletteDropDownButtonItem2.Name = "skinPaletteDropDownButtonItem2";
            // 
            // skinBarSubItem2
            // 
            this.skinBarSubItem2.Caption = "Temalar";
            this.skinBarSubItem2.Id = 3;
            this.skinBarSubItem2.Name = "skinBarSubItem2";
            this.skinBarSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinPaletteDropDownButtonItem1,
            this.skinBarSubItem1,
            this.skinPaletteDropDownButtonItem2,
            this.skinBarSubItem2});
            this.fluentFormDefaultManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.skinBarSubItem2)});
            this.popupMenu2.Manager = this.fluentFormDefaultManager1;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // btn_MailError
            // 
            this.btn_MailError.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement4.ImageOptions.Image")));
            this.btn_MailError.Name = "btn_MailError";
            this.btn_MailError.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btn_MailError.Text = "Mail Hata ";
            this.btn_MailError.Click += new System.EventHandler(this.btn_MailError_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1102, 473);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("HomeForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nokta Bilgi İşlem Bilgilendirme V1.0.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeForm_FormClosed);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_SQLForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_WhatsappSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_Thema;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem2;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem2;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_ReportForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_SendPerson;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_SQLITEForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_softwareLog;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_userSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_StartService;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_StopService;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_MailSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_WebService;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_sendCount;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btn_MailError;
    }
}