namespace NoktaBilgiNotificationUI.Forms
{
    partial class SendPersonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendPersonForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btn_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Mail = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msk_WPNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PersonName = new DevExpress.XtraEditors.TextEdit();
            this.chk_Status = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PersonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Status.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(493, 534);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.chk_Status);
            this.groupControl2.Controls.Add(this.btn_Clear);
            this.groupControl2.Controls.Add(this.btn_Save);
            this.groupControl2.Controls.Add(this.txt_Mail);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.msk_WPNo);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.txt_PersonName);
            this.groupControl2.Location = new System.Drawing.Point(513, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(279, 212);
            this.groupControl2.TabIndex = 15;
            this.groupControl2.Text = "İşlemler";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_Clear.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Clear.Appearance.Options.UseBackColor = true;
            this.btn_Clear.Appearance.Options.UseFont = true;
            this.btn_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Clear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Clear.ImageOptions.Image")));
            this.btn_Clear.Location = new System.Drawing.Point(241, 0);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Clear.Size = new System.Drawing.Size(38, 29);
            this.btn_Clear.TabIndex = 16;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(86, 166);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(180, 40);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Kaydet";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Mail
            // 
            this.txt_Mail.Location = new System.Drawing.Point(86, 101);
            this.txt_Mail.Name = "txt_Mail";
            this.txt_Mail.Properties.MaxLength = 50;
            this.txt_Mail.Size = new System.Drawing.Size(180, 20);
            this.txt_Mail.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Telefon:";
            // 
            // msk_WPNo
            // 
            this.msk_WPNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.msk_WPNo.Location = new System.Drawing.Point(86, 73);
            this.msk_WPNo.Mask = "+900000000000";
            this.msk_WPNo.Name = "msk_WPNo";
            this.msk_WPNo.Size = new System.Drawing.Size(180, 20);
            this.msk_WPNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Yetkili Adı:";
            // 
            // txt_PersonName
            // 
            this.txt_PersonName.Location = new System.Drawing.Point(86, 46);
            this.txt_PersonName.Name = "txt_PersonName";
            this.txt_PersonName.Properties.MaxLength = 50;
            this.txt_PersonName.Size = new System.Drawing.Size(180, 20);
            this.txt_PersonName.TabIndex = 0;
            // 
            // chk_Status
            // 
            this.chk_Status.Location = new System.Drawing.Point(86, 127);
            this.chk_Status.Name = "chk_Status";
            this.chk_Status.Properties.Caption = "Aktif Mi ?";
            this.chk_Status.Size = new System.Drawing.Size(88, 20);
            this.chk_Status.TabIndex = 3;
            // 
            // SendPersonForm
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(941, 534);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("SendPersonForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "SendPersonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gönderilecek Kişiler";
            this.Load += new System.EventHandler(this.SendPersonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PersonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Status.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txt_Mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox msk_WPNo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_PersonName;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Clear;
        private DevExpress.XtraEditors.CheckEdit chk_Status;
    }
}