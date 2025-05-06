namespace NoktaBilgiNotificationUI.Forms
{
    partial class ReportDesignerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDesignerForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txt_ReportName = new DevExpress.XtraEditors.TextEdit();
            this.txt_StartTime = new DevExpress.XtraEditors.TimeEdit();
            this.cmb_SendType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chk_Sunday = new DevExpress.XtraEditors.CheckEdit();
            this.chk_Thursday = new DevExpress.XtraEditors.CheckEdit();
            this.chk_Saturday = new DevExpress.XtraEditors.CheckEdit();
            this.chk_Monday = new DevExpress.XtraEditors.CheckEdit();
            this.chk_Friday = new DevExpress.XtraEditors.CheckEdit();
            this.chk_Tuesday = new DevExpress.XtraEditors.CheckEdit();
            this.chk_Wednesday = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chk_IsActive = new DevExpress.XtraEditors.CheckEdit();
            this.nmr_Repeat = new System.Windows.Forms.NumericUpDown();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.gridControlPerson = new DevExpress.XtraGrid.GridControl();
            this.gridViewPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupPersonSelector = new DevExpress.XtraEditors.PopupContainerEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.rch_Desc = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReportName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SendType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Sunday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Thursday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Saturday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Monday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Friday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Tuesday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Wednesday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_IsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Repeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupPersonSelector.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(465, 539);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // txt_ReportName
            // 
            this.txt_ReportName.Location = new System.Drawing.Point(156, 37);
            this.txt_ReportName.Name = "txt_ReportName";
            this.txt_ReportName.Properties.MaxLength = 50;
            this.txt_ReportName.Size = new System.Drawing.Size(187, 20);
            this.txt_ReportName.TabIndex = 0;
            // 
            // txt_StartTime
            // 
            this.txt_StartTime.EditValue = new System.DateTime(2025, 4, 29, 0, 0, 0, 0);
            this.txt_StartTime.Location = new System.Drawing.Point(156, 114);
            this.txt_StartTime.Name = "txt_StartTime";
            this.txt_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_StartTime.Size = new System.Drawing.Size(189, 20);
            this.txt_StartTime.TabIndex = 2;
            // 
            // cmb_SendType
            // 
            this.cmb_SendType.Location = new System.Drawing.Point(156, 169);
            this.cmb_SendType.Name = "cmb_SendType";
            this.cmb_SendType.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.cmb_SendType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_SendType.Properties.Items.AddRange(new object[] {
            "Whatsapp",
            "Mail",
            "Gönderim Yapılmıyacak"});
            this.cmb_SendType.Size = new System.Drawing.Size(189, 20);
            this.cmb_SendType.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.chk_Sunday);
            this.groupControl1.Controls.Add(this.chk_Thursday);
            this.groupControl1.Controls.Add(this.chk_Saturday);
            this.groupControl1.Controls.Add(this.chk_Monday);
            this.groupControl1.Controls.Add(this.chk_Friday);
            this.groupControl1.Controls.Add(this.chk_Tuesday);
            this.groupControl1.Controls.Add(this.chk_Wednesday);
            this.groupControl1.Location = new System.Drawing.Point(514, 244);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(353, 102);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Günler";
            // 
            // chk_Sunday
            // 
            this.chk_Sunday.Location = new System.Drawing.Point(256, 71);
            this.chk_Sunday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Sunday.Name = "chk_Sunday";
            this.chk_Sunday.Properties.Caption = "Pazar";
            this.chk_Sunday.Size = new System.Drawing.Size(63, 20);
            this.chk_Sunday.TabIndex = 12;
            // 
            // chk_Thursday
            // 
            this.chk_Thursday.Location = new System.Drawing.Point(19, 71);
            this.chk_Thursday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Thursday.Name = "chk_Thursday";
            this.chk_Thursday.Properties.Caption = "Perşembe";
            this.chk_Thursday.Size = new System.Drawing.Size(71, 20);
            this.chk_Thursday.TabIndex = 9;
            // 
            // chk_Saturday
            // 
            this.chk_Saturday.Location = new System.Drawing.Point(173, 71);
            this.chk_Saturday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Saturday.Name = "chk_Saturday";
            this.chk_Saturday.Properties.Caption = "Cumartesi";
            this.chk_Saturday.Size = new System.Drawing.Size(73, 20);
            this.chk_Saturday.TabIndex = 11;
            // 
            // chk_Monday
            // 
            this.chk_Monday.Location = new System.Drawing.Point(19, 37);
            this.chk_Monday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Monday.Name = "chk_Monday";
            this.chk_Monday.Properties.Caption = "Pazartesi";
            this.chk_Monday.Size = new System.Drawing.Size(78, 20);
            this.chk_Monday.TabIndex = 6;
            // 
            // chk_Friday
            // 
            this.chk_Friday.Location = new System.Drawing.Point(104, 71);
            this.chk_Friday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Friday.Name = "chk_Friday";
            this.chk_Friday.Properties.Caption = "Cuma";
            this.chk_Friday.Size = new System.Drawing.Size(64, 20);
            this.chk_Friday.TabIndex = 10;
            // 
            // chk_Tuesday
            // 
            this.chk_Tuesday.Location = new System.Drawing.Point(104, 37);
            this.chk_Tuesday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Tuesday.Name = "chk_Tuesday";
            this.chk_Tuesday.Properties.Caption = "Salı";
            this.chk_Tuesday.Size = new System.Drawing.Size(64, 20);
            this.chk_Tuesday.TabIndex = 7;
            // 
            // chk_Wednesday
            // 
            this.chk_Wednesday.Location = new System.Drawing.Point(173, 37);
            this.chk_Wednesday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Wednesday.Name = "chk_Wednesday";
            this.chk_Wednesday.Properties.Caption = "Çarşamba";
            this.chk_Wednesday.Size = new System.Drawing.Size(73, 20);
            this.chk_Wednesday.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rapor Adı:";
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(514, 493);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(353, 30);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "Kaydet";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Başlangıç Saati:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kaç Dakikada Bir Çalışacak:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Gönderim Türü:";
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.rch_Desc);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.chk_IsActive);
            this.groupControl2.Controls.Add(this.nmr_Repeat);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.txt_ReportName);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.txt_StartTime);
            this.groupControl2.Controls.Add(this.cmb_SendType);
            this.groupControl2.Location = new System.Drawing.Point(514, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(353, 239);
            this.groupControl2.TabIndex = 14;
            this.groupControl2.Text = "İşlemler";
            // 
            // chk_IsActive
            // 
            this.chk_IsActive.Location = new System.Drawing.Point(156, 198);
            this.chk_IsActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_IsActive.Name = "chk_IsActive";
            this.chk_IsActive.Properties.Caption = "Aktif Mi ?";
            this.chk_IsActive.Size = new System.Drawing.Size(75, 20);
            this.chk_IsActive.TabIndex = 5;
            // 
            // nmr_Repeat
            // 
            this.nmr_Repeat.Location = new System.Drawing.Point(156, 141);
            this.nmr_Repeat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmr_Repeat.Maximum = new decimal(new int[] {
            43829,
            0,
            0,
            0});
            this.nmr_Repeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_Repeat.Name = "nmr_Repeat";
            this.nmr_Repeat.Size = new System.Drawing.Size(189, 21);
            this.nmr_Repeat.TabIndex = 3;
            this.nmr_Repeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupControl3
            // 
            this.groupControl3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImageOptions.Image")));
            this.groupControl3.Controls.Add(this.popupContainerControl1);
            this.groupControl3.Controls.Add(this.popupPersonSelector);
            this.groupControl3.Location = new System.Drawing.Point(514, 373);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(353, 81);
            this.groupControl3.TabIndex = 16;
            this.groupControl3.Text = "Gönderilecek Kişiler";
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.gridControlPerson);
            this.popupContainerControl1.Location = new System.Drawing.Point(30, 73);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(200, 40);
            this.popupContainerControl1.TabIndex = 18;
            // 
            // gridControlPerson
            // 
            this.gridControlPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPerson.Location = new System.Drawing.Point(0, 0);
            this.gridControlPerson.MainView = this.gridViewPerson;
            this.gridControlPerson.Name = "gridControlPerson";
            this.gridControlPerson.Size = new System.Drawing.Size(200, 40);
            this.gridControlPerson.TabIndex = 17;
            this.gridControlPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPerson});
            // 
            // gridViewPerson
            // 
            this.gridViewPerson.GridControl = this.gridControlPerson;
            this.gridViewPerson.Name = "gridViewPerson";
            this.gridViewPerson.ShownEditor += new System.EventHandler(this.gridViewPerson_ShownEditor);
            // 
            // popupPersonSelector
            // 
            this.popupPersonSelector.Location = new System.Drawing.Point(18, 47);
            this.popupPersonSelector.Name = "popupPersonSelector";
            this.popupPersonSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupPersonSelector.Size = new System.Drawing.Size(300, 20);
            this.popupPersonSelector.TabIndex = 13;
            this.popupPersonSelector.Click += new System.EventHandler(this.popupPersonSelector_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Rapor Açıklama:";
            // 
            // rch_Desc
            // 
            this.rch_Desc.Location = new System.Drawing.Point(156, 67);
            this.rch_Desc.Name = "rch_Desc";
            this.rch_Desc.Size = new System.Drawing.Size(188, 37);
            this.rch_Desc.TabIndex = 1;
            this.rch_Desc.Text = "";
            // 
            // ReportDesignerForm
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(878, 539);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.richTextBox1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("ReportDesignerForm.IconOptions.Image")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ReportDesignerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor";
            this.Load += new System.EventHandler(this.ReportDesignerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReportDesignerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReportName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SendType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_Sunday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Thursday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Saturday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Monday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Friday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Tuesday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Wednesday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_IsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Repeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupPersonSelector.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.TextEdit txt_ReportName;
        private DevExpress.XtraEditors.TimeEdit txt_StartTime;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_SendType;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit chk_Sunday;
        private DevExpress.XtraEditors.CheckEdit chk_Thursday;
        private DevExpress.XtraEditors.CheckEdit chk_Saturday;
        private DevExpress.XtraEditors.CheckEdit chk_Monday;
        private DevExpress.XtraEditors.CheckEdit chk_Friday;
        private DevExpress.XtraEditors.CheckEdit chk_Tuesday;
        private DevExpress.XtraEditors.CheckEdit chk_Wednesday;
        private DevExpress.XtraEditors.CheckEdit chk_IsActive;
        private System.Windows.Forms.NumericUpDown nmr_Repeat;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.PopupContainerEdit popupPersonSelector;
        private DevExpress.XtraGrid.GridControl gridControlPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPerson;
        private System.Windows.Forms.RichTextBox rch_Desc;
        private System.Windows.Forms.Label label5;
    }
}