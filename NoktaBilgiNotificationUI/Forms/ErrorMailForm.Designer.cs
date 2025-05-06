namespace NoktaBilgiNotificationUI.Forms
{
    partial class ErrorMailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMailForm));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_CompanyName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Email = new DevExpress.XtraEditors.TextEdit();
            this.btn_SendMail = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Update = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Server = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_SSL = new System.Windows.Forms.CheckBox();
            this.txt_Port = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Server.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.txt_CompanyName);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.txt_Email);
            this.groupControl2.Controls.Add(this.btn_SendMail);
            this.groupControl2.Controls.Add(this.btn_Update);
            this.groupControl2.Controls.Add(this.txt_Server);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.txt_Password);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.chk_SSL);
            this.groupControl2.Controls.Add(this.txt_Port);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Location = new System.Drawing.Point(12, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(377, 364);
            this.groupControl2.TabIndex = 75;
            this.groupControl2.Text = "Mail Ayarları";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(20, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 73;
            this.label5.Text = "Şirket Adı";
            // 
            // txt_CompanyName
            // 
            this.txt_CompanyName.Location = new System.Drawing.Point(167, 171);
            this.txt_CompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CompanyName.Name = "txt_CompanyName";
            this.txt_CompanyName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_CompanyName.Properties.Appearance.Options.UseFont = true;
            this.txt_CompanyName.Properties.MaxLength = 50;
            this.txt_CompanyName.Size = new System.Drawing.Size(198, 20);
            this.txt_CompanyName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(20, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 68;
            this.label2.Text = "E-Mail:";
            // 
            // txt_Email
            // 
            this.txt_Email.EditValue = "noreply@noktabilgiislem.com";
            this.txt_Email.Location = new System.Drawing.Point(167, 44);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_Email.Properties.Appearance.Options.UseFont = true;
            this.txt_Email.Properties.MaxLength = 50;
            this.txt_Email.Size = new System.Drawing.Size(198, 20);
            this.txt_Email.TabIndex = 0;
            // 
            // btn_SendMail
            // 
            this.btn_SendMail.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btn_SendMail.Appearance.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.btn_SendMail.Appearance.Options.UseBackColor = true;
            this.btn_SendMail.Appearance.Options.UseFont = true;
            this.btn_SendMail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SendMail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SendMail.ImageOptions.Image")));
            this.btn_SendMail.Location = new System.Drawing.Point(167, 255);
            this.btn_SendMail.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SendMail.Name = "btn_SendMail";
            this.btn_SendMail.Size = new System.Drawing.Size(198, 45);
            this.btn_SendMail.TabIndex = 6;
            this.btn_SendMail.Text = "Test Maili Gönder";
            this.btn_SendMail.Click += new System.EventHandler(this.btn_SendMail_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Update.Appearance.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.btn_Update.Appearance.Options.UseBackColor = true;
            this.btn_Update.Appearance.Options.UseFont = true;
            this.btn_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Update.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.ImageOptions.Image")));
            this.btn_Update.Location = new System.Drawing.Point(167, 308);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(198, 49);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "Kaydet";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // txt_Server
            // 
            this.txt_Server.EditValue = "mail.noktabilgiislem.com";
            this.txt_Server.Location = new System.Drawing.Point(167, 105);
            this.txt_Server.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Server.Name = "txt_Server";
            this.txt_Server.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_Server.Properties.Appearance.Options.UseFont = true;
            this.txt_Server.Properties.MaxLength = 30;
            this.txt_Server.Size = new System.Drawing.Size(198, 20);
            this.txt_Server.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(20, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "Sunucu:";
            // 
            // txt_Password
            // 
            this.txt_Password.EditValue = "fiW_t5:P4-U1s-5K";
            this.txt_Password.Location = new System.Drawing.Point(167, 76);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_Password.Properties.Appearance.Options.UseFont = true;
            this.txt_Password.Properties.MaxLength = 50;
            this.txt_Password.Properties.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(198, 20);
            this.txt_Password.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(20, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 70;
            this.label4.Text = "Şifre:";
            // 
            // chk_SSL
            // 
            this.chk_SSL.AutoSize = true;
            this.chk_SSL.Location = new System.Drawing.Point(167, 199);
            this.chk_SSL.Margin = new System.Windows.Forms.Padding(4);
            this.chk_SSL.Name = "chk_SSL";
            this.chk_SSL.Size = new System.Drawing.Size(99, 17);
            this.chk_SSL.TabIndex = 5;
            this.chk_SSL.Text = "SSL Olucak Mı ?";
            this.chk_SSL.UseVisualStyleBackColor = true;
            // 
            // txt_Port
            // 
            this.txt_Port.EditValue = "587";
            this.txt_Port.Location = new System.Drawing.Point(167, 139);
            this.txt_Port.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_Port.Properties.Appearance.Options.UseFont = true;
            this.txt_Port.Properties.MaxLength = 5;
            this.txt_Port.Size = new System.Drawing.Size(198, 20);
            this.txt_Port.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(20, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 71;
            this.label1.Text = "Port:";
            // 
            // ErrorMailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(837, 492);
            this.Controls.Add(this.groupControl2);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("ErrorMailForm.IconOptions.Image")));
            this.KeyPreview = true;
            this.Name = "ErrorMailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hata Mail Ayarları";
            this.Load += new System.EventHandler(this.ErrorMailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Server.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txt_CompanyName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txt_Email;
        private DevExpress.XtraEditors.SimpleButton btn_SendMail;
        private DevExpress.XtraEditors.SimpleButton btn_Update;
        private DevExpress.XtraEditors.TextEdit txt_Server;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txt_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_SSL;
        private DevExpress.XtraEditors.TextEdit txt_Port;
        private System.Windows.Forms.Label label1;
    }
}