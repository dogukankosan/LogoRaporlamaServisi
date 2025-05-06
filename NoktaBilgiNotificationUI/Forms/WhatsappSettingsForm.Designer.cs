namespace NoktaBilgiNotificationUI.Forms
{
    partial class WhatsappSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhatsappSettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TemplateID = new DevExpress.XtraEditors.TextEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ServiceID = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_WpToken = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_WpClientID = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TemplateID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WpToken.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WpClientID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label1.Location = new System.Drawing.Point(9, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 45;
            this.label1.Text = "Template ID:";
            // 
            // txt_TemplateID
            // 
            this.txt_TemplateID.EditValue = "HX5e08c296214071c98c50b3cf43fdf5e5";
            this.txt_TemplateID.Location = new System.Drawing.Point(225, 155);
            this.txt_TemplateID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TemplateID.Name = "txt_TemplateID";
            this.txt_TemplateID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_TemplateID.Properties.Appearance.Options.UseFont = true;
            this.txt_TemplateID.Properties.MaxLength = 250;
            this.txt_TemplateID.Properties.PasswordChar = '*';
            this.txt_TemplateID.Size = new System.Drawing.Size(260, 24);
            this.txt_TemplateID.TabIndex = 3;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(225, 195);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(260, 54);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Kaydet";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label7.Location = new System.Drawing.Point(9, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Servis ID:";
            // 
            // txt_ServiceID
            // 
            this.txt_ServiceID.EditValue = "MGd9674a5df108741733755b68397c691e";
            this.txt_ServiceID.Location = new System.Drawing.Point(225, 121);
            this.txt_ServiceID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ServiceID.Name = "txt_ServiceID";
            this.txt_ServiceID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_ServiceID.Properties.Appearance.Options.UseFont = true;
            this.txt_ServiceID.Properties.MaxLength = 250;
            this.txt_ServiceID.Properties.PasswordChar = '*';
            this.txt_ServiceID.Size = new System.Drawing.Size(260, 24);
            this.txt_ServiceID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label5.Location = new System.Drawing.Point(9, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 21);
            this.label5.TabIndex = 43;
            this.label5.Text = "Whatsapp Token:";
            // 
            // txt_WpToken
            // 
            this.txt_WpToken.EditValue = "383d93c58301e29276eb914640ced618";
            this.txt_WpToken.Location = new System.Drawing.Point(225, 89);
            this.txt_WpToken.Margin = new System.Windows.Forms.Padding(4);
            this.txt_WpToken.Name = "txt_WpToken";
            this.txt_WpToken.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_WpToken.Properties.Appearance.Options.UseFont = true;
            this.txt_WpToken.Properties.MaxLength = 250;
            this.txt_WpToken.Properties.PasswordChar = '*';
            this.txt_WpToken.Size = new System.Drawing.Size(260, 24);
            this.txt_WpToken.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.label4.Location = new System.Drawing.Point(9, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 21);
            this.label4.TabIndex = 42;
            this.label4.Text = "Whatsapp ClientID:";
            // 
            // txt_WpClientID
            // 
            this.txt_WpClientID.EditValue = "AC0d37922d84b7373f712175b1e59b84c5";
            this.txt_WpClientID.Location = new System.Drawing.Point(225, 50);
            this.txt_WpClientID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_WpClientID.Name = "txt_WpClientID";
            this.txt_WpClientID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txt_WpClientID.Properties.Appearance.Options.UseFont = true;
            this.txt_WpClientID.Properties.MaxLength = 250;
            this.txt_WpClientID.Properties.PasswordChar = '*';
            this.txt_WpClientID.Size = new System.Drawing.Size(260, 24);
            this.txt_WpClientID.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txt_WpClientID);
            this.groupControl1.Controls.Add(this.txt_TemplateID);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Controls.Add(this.txt_WpToken);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txt_ServiceID);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(508, 260);
            this.groupControl1.TabIndex = 46;
            this.groupControl1.Text = "Whatsapp Ayarları";
            // 
            // WhatsappSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(863, 528);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("WhatsappSettingsForm.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "WhatsappSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Whatsapp Ayarları";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WhatsappSettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.WhatsappSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_TemplateID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WpToken.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WpClientID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_TemplateID;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txt_ServiceID;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txt_WpToken;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txt_WpClientID;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}