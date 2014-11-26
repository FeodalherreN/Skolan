namespace Uppgift_1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCurrentMusic = new System.Windows.Forms.Label();
            this.btnStopMusic = new System.Windows.Forms.Button();
            this.btnPlayMusic = new System.Windows.Forms.Button();
            this.btnOpenMusic = new System.Windows.Forms.Button();
            this.lblMusic = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMove = new System.Windows.Forms.Label();
            this.FloatingLabelBox = new System.Windows.Forms.PictureBox();
            this.btnStopDisplay = new System.Windows.Forms.Button();
            this.btnStartDisplay = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trianglepicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStopTriangle = new System.Windows.Forms.Button();
            this.btnStartTriangle = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloatingLabelBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trianglepicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCurrentMusic);
            this.groupBox1.Controls.Add(this.btnStopMusic);
            this.groupBox1.Controls.Add(this.btnPlayMusic);
            this.groupBox1.Controls.Add(this.btnOpenMusic);
            this.groupBox1.Controls.Add(this.lblMusic);
            this.groupBox1.Location = new System.Drawing.Point(31, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music player";
            // 
            // lblCurrentMusic
            // 
            this.lblCurrentMusic.AutoSize = true;
            this.lblCurrentMusic.Location = new System.Drawing.Point(108, 37);
            this.lblCurrentMusic.Name = "lblCurrentMusic";
            this.lblCurrentMusic.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentMusic.TabIndex = 4;
            // 
            // btnStopMusic
            // 
            this.btnStopMusic.Location = new System.Drawing.Point(218, 71);
            this.btnStopMusic.Name = "btnStopMusic";
            this.btnStopMusic.Size = new System.Drawing.Size(75, 23);
            this.btnStopMusic.TabIndex = 3;
            this.btnStopMusic.Text = "Stop";
            this.btnStopMusic.UseVisualStyleBackColor = true;
            this.btnStopMusic.Click += new System.EventHandler(this.btnStopMusic_Click);
            // 
            // btnPlayMusic
            // 
            this.btnPlayMusic.Location = new System.Drawing.Point(111, 71);
            this.btnPlayMusic.Name = "btnPlayMusic";
            this.btnPlayMusic.Size = new System.Drawing.Size(75, 23);
            this.btnPlayMusic.TabIndex = 2;
            this.btnPlayMusic.Text = "Play";
            this.btnPlayMusic.UseVisualStyleBackColor = true;
            this.btnPlayMusic.Click += new System.EventHandler(this.btnPlayMusic_Click);
            // 
            // btnOpenMusic
            // 
            this.btnOpenMusic.Location = new System.Drawing.Point(6, 71);
            this.btnOpenMusic.Name = "btnOpenMusic";
            this.btnOpenMusic.Size = new System.Drawing.Size(75, 23);
            this.btnOpenMusic.TabIndex = 1;
            this.btnOpenMusic.Text = "Open";
            this.btnOpenMusic.UseVisualStyleBackColor = true;
            this.btnOpenMusic.Click += new System.EventHandler(this.btnOpenMusic_Click);
            // 
            // lblMusic
            // 
            this.lblMusic.AutoSize = true;
            this.lblMusic.Location = new System.Drawing.Point(6, 37);
            this.lblMusic.Name = "lblMusic";
            this.lblMusic.Size = new System.Drawing.Size(95, 13);
            this.lblMusic.TabIndex = 0;
            this.lblMusic.Text = "Loaded Audio File:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMove);
            this.groupBox2.Controls.Add(this.FloatingLabelBox);
            this.groupBox2.Controls.Add(this.btnStopDisplay);
            this.groupBox2.Controls.Add(this.btnStartDisplay);
            this.groupBox2.Location = new System.Drawing.Point(31, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 186);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display Thread";
            // 
            // lblMove
            // 
            this.lblMove.AutoSize = true;
            this.lblMove.Location = new System.Drawing.Point(96, 80);
            this.lblMove.Name = "lblMove";
            this.lblMove.Size = new System.Drawing.Size(75, 13);
            this.lblMove.TabIndex = 6;
            this.lblMove.Text = "DisplayThread";
            // 
            // FloatingLabelBox
            // 
            this.FloatingLabelBox.Location = new System.Drawing.Point(9, 20);
            this.FloatingLabelBox.Name = "FloatingLabelBox";
            this.FloatingLabelBox.Size = new System.Drawing.Size(248, 131);
            this.FloatingLabelBox.TabIndex = 5;
            this.FloatingLabelBox.TabStop = false;
            // 
            // btnStopDisplay
            // 
            this.btnStopDisplay.Location = new System.Drawing.Point(159, 157);
            this.btnStopDisplay.Name = "btnStopDisplay";
            this.btnStopDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnStopDisplay.TabIndex = 4;
            this.btnStopDisplay.Text = "Stop";
            this.btnStopDisplay.UseVisualStyleBackColor = true;
            this.btnStopDisplay.Click += new System.EventHandler(this.btnStopDisplay_Click);
            // 
            // btnStartDisplay
            // 
            this.btnStartDisplay.Location = new System.Drawing.Point(6, 157);
            this.btnStartDisplay.Name = "btnStartDisplay";
            this.btnStartDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnStartDisplay.TabIndex = 3;
            this.btnStartDisplay.Text = "Start display";
            this.btnStartDisplay.UseVisualStyleBackColor = true;
            this.btnStartDisplay.Click += new System.EventHandler(this.btnStartDisplay_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trianglepicture);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.btnStopTriangle);
            this.groupBox3.Controls.Add(this.btnStartTriangle);
            this.groupBox3.Location = new System.Drawing.Point(336, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 186);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Triangle Thread";
            // 
            // trianglepicture
            // 
            this.trianglepicture.Location = new System.Drawing.Point(78, 43);
            this.trianglepicture.Name = "trianglepicture";
            this.trianglepicture.Size = new System.Drawing.Size(90, 80);
            this.trianglepicture.TabIndex = 3;
            this.trianglepicture.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 131);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnStopTriangle
            // 
            this.btnStopTriangle.Location = new System.Drawing.Point(136, 157);
            this.btnStopTriangle.Name = "btnStopTriangle";
            this.btnStopTriangle.Size = new System.Drawing.Size(75, 23);
            this.btnStopTriangle.TabIndex = 1;
            this.btnStopTriangle.Text = "Stop";
            this.btnStopTriangle.UseVisualStyleBackColor = true;
            this.btnStopTriangle.Click += new System.EventHandler(this.btnStopTriangle_Click);
            // 
            // btnStartTriangle
            // 
            this.btnStartTriangle.Location = new System.Drawing.Point(20, 157);
            this.btnStartTriangle.Name = "btnStartTriangle";
            this.btnStartTriangle.Size = new System.Drawing.Size(75, 23);
            this.btnStartTriangle.TabIndex = 0;
            this.btnStartTriangle.Text = "Start rotate";
            this.btnStartTriangle.UseVisualStyleBackColor = true;
            this.btnStartTriangle.Click += new System.EventHandler(this.btnStartTriangle_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 375);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Assignment 1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloatingLabelBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trianglepicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMusic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCurrentMusic;
        private System.Windows.Forms.Button btnStopMusic;
        private System.Windows.Forms.Button btnPlayMusic;
        private System.Windows.Forms.Button btnOpenMusic;
        private System.Windows.Forms.PictureBox FloatingLabelBox;
        private System.Windows.Forms.Button btnStopDisplay;
        private System.Windows.Forms.Button btnStartDisplay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStopTriangle;
        private System.Windows.Forms.Button btnStartTriangle;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblMove;
        private System.Windows.Forms.PictureBox trianglepicture;
    }
}

