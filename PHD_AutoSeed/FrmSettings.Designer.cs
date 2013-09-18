namespace PHD_AutoSeed
{
    partial class FrmSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbAnonymous = new System.Windows.Forms.CheckBox();
            this.lblAnonymous = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.txt_uid = new System.Windows.Forms.TextBox();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.lbl_uid = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtDownload = new System.Windows.Forms.TextBox();
            this.lblDownload = new System.Windows.Forms.Label();
            this.btnTorrents = new System.Windows.Forms.Button();
            this.txtTorrents = new System.Windows.Forms.TextBox();
            this.lblTorrents = new System.Windows.Forms.Label();
            this.btnRemoveWatch = new System.Windows.Forms.Button();
            this.btnAddWatch = new System.Windows.Forms.Button();
            this.lstWatch = new System.Windows.Forms.ListBox();
            this.lblWatch = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblWeb = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWebsite);
            this.groupBox1.Controls.Add(this.lblWeb);
            this.groupBox1.Controls.Add(this.chbAnonymous);
            this.groupBox1.Controls.Add(this.lblAnonymous);
            this.groupBox1.Controls.Add(this.txt_pass);
            this.groupBox1.Controls.Add(this.txt_login);
            this.groupBox1.Controls.Add(this.txt_uid);
            this.groupBox1.Controls.Add(this.lbl_login);
            this.groupBox1.Controls.Add(this.lbl_pass);
            this.groupBox1.Controls.Add(this.lbl_uid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cookies";
            // 
            // chbAnonymous
            // 
            this.chbAnonymous.AutoSize = true;
            this.chbAnonymous.Location = new System.Drawing.Point(127, 95);
            this.chbAnonymous.Name = "chbAnonymous";
            this.chbAnonymous.Size = new System.Drawing.Size(15, 14);
            this.chbAnonymous.TabIndex = 7;
            this.chbAnonymous.UseVisualStyleBackColor = true;
            // 
            // lblAnonymous
            // 
            this.lblAnonymous.AutoSize = true;
            this.lblAnonymous.CausesValidation = false;
            this.lblAnonymous.Location = new System.Drawing.Point(27, 100);
            this.lblAnonymous.Name = "lblAnonymous";
            this.lblAnonymous.Size = new System.Drawing.Size(59, 12);
            this.lblAnonymous.TabIndex = 6;
            this.lblAnonymous.Text = "anonymous";
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(127, 65);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(100, 21);
            this.txt_pass.TabIndex = 5;
            // 
            // txt_login
            // 
            this.txt_login.Location = new System.Drawing.Point(127, 38);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(100, 21);
            this.txt_login.TabIndex = 4;
            // 
            // txt_uid
            // 
            this.txt_uid.Location = new System.Drawing.Point(127, 11);
            this.txt_uid.Name = "txt_uid";
            this.txt_uid.Size = new System.Drawing.Size(100, 21);
            this.txt_uid.TabIndex = 3;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(26, 76);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(83, 12);
            this.lbl_login.TabIndex = 2;
            this.lbl_login.Text = "c_secure_pass";
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Location = new System.Drawing.Point(26, 47);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(89, 12);
            this.lbl_pass.TabIndex = 1;
            this.lbl_pass.Text = "c_secure_login";
            // 
            // lbl_uid
            // 
            this.lbl_uid.AutoSize = true;
            this.lbl_uid.Location = new System.Drawing.Point(26, 21);
            this.lbl_uid.Name = "lbl_uid";
            this.lbl_uid.Size = new System.Drawing.Size(77, 12);
            this.lbl_uid.TabIndex = 0;
            this.lbl_uid.Text = "c_secure_uid";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDownload);
            this.groupBox2.Controls.Add(this.txtDownload);
            this.groupBox2.Controls.Add(this.lblDownload);
            this.groupBox2.Controls.Add(this.btnTorrents);
            this.groupBox2.Controls.Add(this.txtTorrents);
            this.groupBox2.Controls.Add(this.lblTorrents);
            this.groupBox2.Controls.Add(this.btnRemoveWatch);
            this.groupBox2.Controls.Add(this.btnAddWatch);
            this.groupBox2.Controls.Add(this.lstWatch);
            this.groupBox2.Controls.Add(this.lblWatch);
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 235);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Torrents";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(515, 201);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(24, 23);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "...";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtDownload
            // 
            this.txtDownload.Location = new System.Drawing.Point(20, 203);
            this.txtDownload.Name = "txtDownload";
            this.txtDownload.Size = new System.Drawing.Size(488, 21);
            this.txtDownload.TabIndex = 8;
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(20, 174);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(95, 12);
            this.lblDownload.TabIndex = 7;
            this.lblDownload.Text = "Download Folder";
            // 
            // btnTorrents
            // 
            this.btnTorrents.Location = new System.Drawing.Point(515, 133);
            this.btnTorrents.Name = "btnTorrents";
            this.btnTorrents.Size = new System.Drawing.Size(24, 23);
            this.btnTorrents.TabIndex = 6;
            this.btnTorrents.Text = "...";
            this.btnTorrents.UseVisualStyleBackColor = true;
            this.btnTorrents.Click += new System.EventHandler(this.btnTorrents_Click);
            // 
            // txtTorrents
            // 
            this.txtTorrents.Location = new System.Drawing.Point(20, 135);
            this.txtTorrents.Name = "txtTorrents";
            this.txtTorrents.Size = new System.Drawing.Size(488, 21);
            this.txtTorrents.TabIndex = 5;
            // 
            // lblTorrents
            // 
            this.lblTorrents.AutoSize = true;
            this.lblTorrents.Location = new System.Drawing.Point(18, 119);
            this.lblTorrents.Name = "lblTorrents";
            this.lblTorrents.Size = new System.Drawing.Size(95, 12);
            this.lblTorrents.TabIndex = 4;
            this.lblTorrents.Text = "Torrents Folder";
            // 
            // btnRemoveWatch
            // 
            this.btnRemoveWatch.Location = new System.Drawing.Point(514, 89);
            this.btnRemoveWatch.Name = "btnRemoveWatch";
            this.btnRemoveWatch.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveWatch.TabIndex = 3;
            this.btnRemoveWatch.Text = "-";
            this.btnRemoveWatch.UseVisualStyleBackColor = true;
            this.btnRemoveWatch.Click += new System.EventHandler(this.btnRemoveWatch_Click);
            // 
            // btnAddWatch
            // 
            this.btnAddWatch.Location = new System.Drawing.Point(514, 36);
            this.btnAddWatch.Name = "btnAddWatch";
            this.btnAddWatch.Size = new System.Drawing.Size(25, 23);
            this.btnAddWatch.TabIndex = 2;
            this.btnAddWatch.Text = "+";
            this.btnAddWatch.UseVisualStyleBackColor = true;
            this.btnAddWatch.Click += new System.EventHandler(this.btnAddWatch_Click);
            // 
            // lstWatch
            // 
            this.lstWatch.FormattingEnabled = true;
            this.lstWatch.HorizontalScrollbar = true;
            this.lstWatch.ItemHeight = 12;
            this.lstWatch.Location = new System.Drawing.Point(18, 36);
            this.lstWatch.Name = "lstWatch";
            this.lstWatch.Size = new System.Drawing.Size(490, 76);
            this.lstWatch.TabIndex = 1;
            // 
            // lblWatch
            // 
            this.lblWatch.AutoSize = true;
            this.lblWatch.Location = new System.Drawing.Point(16, 21);
            this.lblWatch.Name = "lblWatch";
            this.lblWatch.Size = new System.Drawing.Size(77, 12);
            this.lblWatch.TabIndex = 0;
            this.lblWatch.Text = "Watch Folder";
            // 
            // btnReLoad
            // 
            this.btnReLoad.Location = new System.Drawing.Point(139, 411);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(75, 23);
            this.btnReLoad.TabIndex = 2;
            this.btnReLoad.Text = "ReLoad";
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 411);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblWeb
            // 
            this.lblWeb.AutoSize = true;
            this.lblWeb.Location = new System.Drawing.Point(27, 122);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(47, 12);
            this.lblWeb.TabIndex = 8;
            this.lblWeb.Text = "website";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(127, 119);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(381, 21);
            this.txtWebsite.TabIndex = 9;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 449);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSettings";
            this.Text = "PHD_AutoSeed";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Label lbl_uid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.TextBox txt_uid;
        private System.Windows.Forms.Button btnRemoveWatch;
        private System.Windows.Forms.Button btnAddWatch;
        private System.Windows.Forms.ListBox lstWatch;
        private System.Windows.Forms.Label lblWatch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblTorrents;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtDownload;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Button btnTorrents;
        private System.Windows.Forms.TextBox txtTorrents;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chbAnonymous;
        private System.Windows.Forms.Label lblAnonymous;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblWeb;
    }
}

