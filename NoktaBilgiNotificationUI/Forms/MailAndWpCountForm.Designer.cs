namespace NoktaBilgiNotificationUI.Forms
{
    partial class MailAndWpCountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailAndWpCountForm));
            this.nmr_wp = new System.Windows.Forms.NumericUpDown();
            this.nmr_mail = new System.Windows.Forms.NumericUpDown();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_wp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_mail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nmr_wp
            // 
            this.nmr_wp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nmr_wp.Location = new System.Drawing.Point(143, 85);
            this.nmr_wp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmr_wp.Name = "nmr_wp";
            this.nmr_wp.Size = new System.Drawing.Size(195, 23);
            this.nmr_wp.TabIndex = 1;
            this.nmr_wp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmr_mail
            // 
            this.nmr_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nmr_mail.Location = new System.Drawing.Point(143, 40);
            this.nmr_mail.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmr_mail.Name = "nmr_mail";
            this.nmr_mail.Size = new System.Drawing.Size(195, 23);
            this.nmr_mail.TabIndex = 0;
            this.nmr_mail.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(143, 133);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(195, 44);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Kaydet";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label2.Location = new System.Drawing.Point(5, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Whatsapp Sayi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mail Sayi:";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.nmr_wp);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.nmr_mail);
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(386, 184);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "Mail Ve Whatsapp Gönderim Sayısı";
            // 
            // MailAndWpCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(852, 478);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MailAndWpCountForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "MailAndWpCountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail Ve Whatsapp Gönderim Sayısı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MailAndWpCountForm_FormClosed);
            this.Load += new System.EventHandler(this.MailAndWpCountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmr_wp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_mail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmr_wp;
        private System.Windows.Forms.NumericUpDown nmr_mail;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}