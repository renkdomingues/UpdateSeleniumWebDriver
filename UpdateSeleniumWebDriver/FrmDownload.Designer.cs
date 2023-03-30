namespace UpdateSeleniumWebDriver
{
    partial class frmDownload
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.prgBarDownload = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlDownload = new System.Windows.Forms.Panel();
            this.pnlArqExiste = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlDownload.SuspendLayout();
            this.pnlArqExiste.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgBarDownload
            // 
            this.prgBarDownload.Location = new System.Drawing.Point(7, 143);
            this.prgBarDownload.MarqueeAnimationSpeed = 20;
            this.prgBarDownload.Name = "prgBarDownload";
            this.prgBarDownload.Size = new System.Drawing.Size(418, 23);
            this.prgBarDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBarDownload.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(106, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download em progresso...";
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDirectory.Location = new System.Drawing.Point(137, 121);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(162, 13);
            this.lblDirectory.TabIndex = 2;
            this.lblDirectory.Text = "Seu download finalizará logo!";
            // 
            // btnFechar
            // 
            this.btnFechar.Enabled = false;
            this.btnFechar.Location = new System.Drawing.Point(185, 262);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(193, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Aguarde";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // pnlDownload
            // 
            this.pnlDownload.Controls.Add(this.label1);
            this.pnlDownload.Controls.Add(this.prgBarDownload);
            this.pnlDownload.Controls.Add(this.lblDirectory);
            this.pnlDownload.Location = new System.Drawing.Point(4, 11);
            this.pnlDownload.Name = "pnlDownload";
            this.pnlDownload.Size = new System.Drawing.Size(434, 186);
            this.pnlDownload.TabIndex = 5;
            this.pnlDownload.Visible = false;
            // 
            // pnlArqExiste
            // 
            this.pnlArqExiste.Controls.Add(this.label3);
            this.pnlArqExiste.Location = new System.Drawing.Point(4, 11);
            this.pnlArqExiste.Name = "pnlArqExiste";
            this.pnlArqExiste.Size = new System.Drawing.Size(434, 186);
            this.pnlArqExiste.TabIndex = 6;
            this.pnlArqExiste.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(42, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Você já possui a versão mais recente.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Location = new System.Drawing.Point(4, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 37);
            this.panel1.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 297);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlDownload);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlArqExiste);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebDriver Downloader";
            this.Load += new System.EventHandler(this.frmDownload_Load);
            this.pnlDownload.ResumeLayout(false);
            this.pnlDownload.PerformLayout();
            this.pnlArqExiste.ResumeLayout(false);
            this.pnlArqExiste.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBar prgBarDownload;
        private Label label1;
        private Label lblDirectory;
        private Button btnFechar;
        private Label lblStatus;
        private Panel pnlDownload;
        private Panel pnlArqExiste;
        private Label label3;
        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}