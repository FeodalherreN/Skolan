namespace MacSnapHack
{
    partial class MainForm
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
            this.listUserInfo = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listFriends = new System.Windows.Forms.ListBox();
            this.listSnaps = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listDownload = new System.Windows.Forms.ListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblAvailabeSnaps = new System.Windows.Forms.Label();
            this.CbDebug = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbNotification = new System.Windows.Forms.CheckBox();
            this.CbAutoDowload = new System.Windows.Forms.CheckBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listUserInfo
            // 
            this.listUserInfo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listUserInfo.Font = new System.Drawing.Font("Carlito", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listUserInfo.ForeColor = System.Drawing.Color.Lime;
            this.listUserInfo.FormattingEnabled = true;
            this.listUserInfo.ItemHeight = 18;
            this.listUserInfo.Location = new System.Drawing.Point(12, 58);
            this.listUserInfo.Name = "listUserInfo";
            this.listUserInfo.Size = new System.Drawing.Size(292, 238);
            this.listUserInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F);
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Userinfo";
            // 
            // listFriends
            // 
            this.listFriends.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listFriends.Font = new System.Drawing.Font("Carlito", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFriends.ForeColor = System.Drawing.Color.Lime;
            this.listFriends.FormattingEnabled = true;
            this.listFriends.ItemHeight = 18;
            this.listFriends.Location = new System.Drawing.Point(310, 58);
            this.listFriends.Name = "listFriends";
            this.listFriends.Size = new System.Drawing.Size(304, 238);
            this.listFriends.TabIndex = 3;
            // 
            // listSnaps
            // 
            this.listSnaps.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listSnaps.Font = new System.Drawing.Font("Carlito", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSnaps.ForeColor = System.Drawing.Color.Lime;
            this.listSnaps.FormattingEnabled = true;
            this.listSnaps.ItemHeight = 18;
            this.listSnaps.Location = new System.Drawing.Point(629, 58);
            this.listSnaps.Name = "listSnaps";
            this.listSnaps.Size = new System.Drawing.Size(286, 238);
            this.listSnaps.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F);
            this.label2.Location = new System.Drawing.Point(305, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Friends";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F);
            this.label3.Location = new System.Drawing.Point(624, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "SnapFlow";
            // 
            // listDownload
            // 
            this.listDownload.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listDownload.Font = new System.Drawing.Font("Carlito", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDownload.ForeColor = System.Drawing.Color.Lime;
            this.listDownload.FormattingEnabled = true;
            this.listDownload.ItemHeight = 18;
            this.listDownload.Location = new System.Drawing.Point(17, 380);
            this.listDownload.Name = "listDownload";
            this.listDownload.Size = new System.Drawing.Size(898, 238);
            this.listDownload.TabIndex = 9;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(17, 344);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(246, 30);
            this.btnDownload.TabIndex = 10;
            this.btnDownload.Text = "DOWNLOAD SNAPS";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblAvailabeSnaps
            // 
            this.lblAvailabeSnaps.AutoSize = true;
            this.lblAvailabeSnaps.Font = new System.Drawing.Font("Carlito", 12F);
            this.lblAvailabeSnaps.Location = new System.Drawing.Point(269, 354);
            this.lblAvailabeSnaps.Name = "lblAvailabeSnaps";
            this.lblAvailabeSnaps.Size = new System.Drawing.Size(0, 19);
            this.lblAvailabeSnaps.TabIndex = 11;
            // 
            // CbDebug
            // 
            this.CbDebug.AutoSize = true;
            this.CbDebug.Location = new System.Drawing.Point(131, 19);
            this.CbDebug.Name = "CbDebug";
            this.CbDebug.Size = new System.Drawing.Size(87, 17);
            this.CbDebug.TabIndex = 12;
            this.CbDebug.Text = "Debug mode";
            this.CbDebug.UseVisualStyleBackColor = true;
            this.CbDebug.CheckedChanged += new System.EventHandler(this.CbDebug_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbNotification);
            this.groupBox1.Controls.Add(this.CbDebug);
            this.groupBox1.Controls.Add(this.CbAutoDowload);
            this.groupBox1.Location = new System.Drawing.Point(677, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 71);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // CbNotification
            // 
            this.CbNotification.AutoSize = true;
            this.CbNotification.Location = new System.Drawing.Point(6, 42);
            this.CbNotification.Name = "CbNotification";
            this.CbNotification.Size = new System.Drawing.Size(111, 17);
            this.CbNotification.TabIndex = 1;
            this.CbNotification.Text = "Notification sound";
            this.CbNotification.UseVisualStyleBackColor = true;
            this.CbNotification.CheckedChanged += new System.EventHandler(this.CbNotification_CheckedChanged);
            // 
            // CbAutoDowload
            // 
            this.CbAutoDowload.AutoSize = true;
            this.CbAutoDowload.Location = new System.Drawing.Point(6, 19);
            this.CbAutoDowload.Name = "CbAutoDowload";
            this.CbAutoDowload.Size = new System.Drawing.Size(97, 17);
            this.CbAutoDowload.TabIndex = 0;
            this.CbAutoDowload.Text = "Auto download";
            this.CbAutoDowload.UseVisualStyleBackColor = true;
            this.CbAutoDowload.CheckedChanged += new System.EventHandler(this.CbAutoDowload_CheckedChanged);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(553, 315);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(107, 46);
            this.btnOpenFolder.TabIndex = 14;
            this.btnOpenFolder.Text = "Open snap folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(927, 646);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAvailabeSnaps);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.listDownload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listSnaps);
            this.Controls.Add(this.listFriends);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listUserInfo);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listUserInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listFriends;
        private System.Windows.Forms.ListBox listSnaps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listDownload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblAvailabeSnaps;
        private System.Windows.Forms.CheckBox CbDebug;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CbNotification;
        private System.Windows.Forms.CheckBox CbAutoDowload;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}