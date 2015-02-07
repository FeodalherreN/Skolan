namespace YoutubeDownloader
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.listResult = new System.Windows.Forms.ListBox();
            this.picThumb = new System.Windows.Forms.PictureBox();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.lblNrOfResults = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(375, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(25, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(344, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // listResult
            // 
            this.listResult.FormattingEnabled = true;
            this.listResult.Location = new System.Drawing.Point(13, 40);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(605, 485);
            this.listResult.TabIndex = 2;
            this.listResult.SelectedIndexChanged += new System.EventHandler(this.listResult_SelectedIndexChanged);
            // 
            // picThumb
            // 
            this.picThumb.Location = new System.Drawing.Point(624, 40);
            this.picThumb.Name = "picThumb";
            this.picThumb.Size = new System.Drawing.Size(125, 119);
            this.picThumb.TabIndex = 3;
            this.picThumb.TabStop = false;
            // 
            // BtnDownload
            // 
            this.BtnDownload.Location = new System.Drawing.Point(624, 466);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(125, 59);
            this.BtnDownload.TabIndex = 4;
            this.BtnDownload.Text = "Download";
            this.BtnDownload.UseVisualStyleBackColor = true;
            this.BtnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // lblNrOfResults
            // 
            this.lblNrOfResults.AutoSize = true;
            this.lblNrOfResults.Location = new System.Drawing.Point(457, 19);
            this.lblNrOfResults.Name = "lblNrOfResults";
            this.lblNrOfResults.Size = new System.Drawing.Size(0, 13);
            this.lblNrOfResults.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 552);
            this.Controls.Add(this.lblNrOfResults);
            this.Controls.Add(this.BtnDownload);
            this.Controls.Add(this.picThumb);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "McYoutubeDownloader";
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.PictureBox picThumb;
        private System.Windows.Forms.Button BtnDownload;
        private System.Windows.Forms.Label lblNrOfResults;
    }
}

