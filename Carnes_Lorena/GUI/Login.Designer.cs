namespace GUI
{
    partial class Login
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
            this.moveFrame = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtCont1 = new System.Windows.Forms.TextBox();
            this.txtJug1 = new System.Windows.Forms.TextBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.lblFrame = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.moveFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // moveFrame
            // 
            this.moveFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moveFrame.BackColor = System.Drawing.Color.Black;
            this.moveFrame.Location = new System.Drawing.Point(0, -1);
            this.moveFrame.Name = "moveFrame";
            this.moveFrame.Size = new System.Drawing.Size(530, 30);
            this.moveFrame.TabIndex = 18;
            this.moveFrame.TabStop = false;
            this.moveFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveFrame_MouseDown);
            this.moveFrame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveFrame_MouseMove);
            this.moveFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveFrame_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Black;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimize.Location = new System.Drawing.Point(466, -1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 30);
            this.btnMinimize.TabIndex = 20;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Maroon;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::GUI.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(500, -1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 19;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtCont1
            // 
            this.txtCont1.BackColor = System.Drawing.Color.White;
            this.txtCont1.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCont1.ForeColor = System.Drawing.Color.Black;
            this.txtCont1.Location = new System.Drawing.Point(159, 217);
            this.txtCont1.Multiline = true;
            this.txtCont1.Name = "txtCont1";
            this.txtCont1.PasswordChar = '*';
            this.txtCont1.Size = new System.Drawing.Size(214, 26);
            this.txtCont1.TabIndex = 22;
            this.txtCont1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtJug1
            // 
            this.txtJug1.BackColor = System.Drawing.Color.White;
            this.txtJug1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJug1.ForeColor = System.Drawing.Color.Black;
            this.txtJug1.Location = new System.Drawing.Point(159, 166);
            this.txtJug1.Multiline = true;
            this.txtJug1.Name = "txtJug1";
            this.txtJug1.Size = new System.Drawing.Size(214, 26);
            this.txtJug1.TabIndex = 21;
            this.txtJug1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.Transparent;
            this.btnLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F);
            this.btnLog.ForeColor = System.Drawing.Color.Black;
            this.btnLog.Location = new System.Drawing.Point(159, 285);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(214, 30);
            this.btnLog.TabIndex = 23;
            this.btnLog.Text = "Go";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // lblFrame
            // 
            this.lblFrame.BackColor = System.Drawing.Color.Black;
            this.lblFrame.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblFrame.ForeColor = System.Drawing.Color.DimGray;
            this.lblFrame.Location = new System.Drawing.Point(-4, 0);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(59, 29);
            this.lblFrame.TabIndex = 24;
            this.lblFrame.Text = "Login";
            this.lblFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(199, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 68);
            this.label1.TabIndex = 25;
            this.label1.Text = "LOGIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(530, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFrame);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.txtCont1);
            this.Controls.Add(this.txtJug1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.moveFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.moveFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox moveFrame;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtCont1;
        private System.Windows.Forms.TextBox txtJug1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.Label label1;
    }
}