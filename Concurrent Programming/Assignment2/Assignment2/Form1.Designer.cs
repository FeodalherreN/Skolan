namespace Assignment2
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.listWriteLogger = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.RadioButton();
            this.btnAsync = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.boxString = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.WriteResultLabel = new System.Windows.Forms.Label();
            this.lblTransmitted = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ReadResultLabel = new System.Windows.Forms.Label();
            this.lblRecieved = new System.Windows.Forms.Label();
            this.listReadLogger = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Write Thread Logger";
            // 
            // listWriteLogger
            // 
            this.listWriteLogger.FormattingEnabled = true;
            this.listWriteLogger.Location = new System.Drawing.Point(20, 57);
            this.listWriteLogger.Name = "listWriteLogger";
            this.listWriteLogger.Size = new System.Drawing.Size(303, 368);
            this.listWriteLogger.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Concurrent tester";
            // 
            // btnSync
            // 
            this.btnSync.AutoSize = true;
            this.btnSync.Location = new System.Drawing.Point(331, 82);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(111, 17);
            this.btnSync.TabIndex = 3;
            this.btnSync.TabStop = true;
            this.btnSync.Text = "Syncronous Mode";
            this.btnSync.UseVisualStyleBackColor = true;
            // 
            // btnAsync
            // 
            this.btnAsync.AutoSize = true;
            this.btnAsync.Location = new System.Drawing.Point(331, 106);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(116, 17);
            this.btnAsync.TabIndex = 4;
            this.btnAsync.TabStop = true;
            this.btnAsync.Text = "Asyncronous Mode";
            this.btnAsync.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "String to transfer";
            // 
            // boxString
            // 
            this.boxString.Location = new System.Drawing.Point(331, 164);
            this.boxString.Name = "boxString";
            this.boxString.Size = new System.Drawing.Size(128, 20);
            this.boxString.TabIndex = 6;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(353, 190);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Running status";
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(353, 254);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(89, 61);
            this.pbResult.TabIndex = 9;
            this.pbResult.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(350, 320);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 10;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(353, 362);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // WriteResultLabel
            // 
            this.WriteResultLabel.AutoSize = true;
            this.WriteResultLabel.Location = new System.Drawing.Point(84, 428);
            this.WriteResultLabel.Name = "WriteResultLabel";
            this.WriteResultLabel.Size = new System.Drawing.Size(0, 13);
            this.WriteResultLabel.TabIndex = 12;
            // 
            // lblTransmitted
            // 
            this.lblTransmitted.AutoSize = true;
            this.lblTransmitted.Location = new System.Drawing.Point(16, 519);
            this.lblTransmitted.Name = "lblTransmitted";
            this.lblTransmitted.Size = new System.Drawing.Size(0, 13);
            this.lblTransmitted.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Read Thread Logger";
            // 
            // ReadResultLabel
            // 
            this.ReadResultLabel.AutoSize = true;
            this.ReadResultLabel.Location = new System.Drawing.Point(559, 429);
            this.ReadResultLabel.Name = "ReadResultLabel";
            this.ReadResultLabel.Size = new System.Drawing.Size(0, 13);
            this.ReadResultLabel.TabIndex = 16;
            // 
            // lblRecieved
            // 
            this.lblRecieved.AutoSize = true;
            this.lblRecieved.Location = new System.Drawing.Point(496, 445);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(0, 13);
            this.lblRecieved.TabIndex = 17;
            // 
            // listReadLogger
            // 
            this.listReadLogger.FormattingEnabled = true;
            this.listReadLogger.Location = new System.Drawing.Point(493, 58);
            this.listReadLogger.Name = "listReadLogger";
            this.listReadLogger.Size = new System.Drawing.Size(304, 368);
            this.listReadLogger.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Transmitted";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(496, 428);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Recieved";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 488);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listReadLogger);
            this.Controls.Add(this.lblRecieved);
            this.Controls.Add(this.ReadResultLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTransmitted);
            this.Controls.Add(this.WriteResultLabel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.boxString);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listWriteLogger);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Concurrent Read/Write";
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listWriteLogger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton btnSync;
        private System.Windows.Forms.RadioButton btnAsync;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxString;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label WriteResultLabel;
        private System.Windows.Forms.Label lblTransmitted;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ReadResultLabel;
        private System.Windows.Forms.Label lblRecieved;
        private System.Windows.Forms.ListBox listReadLogger;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

