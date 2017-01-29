namespace GUI
{
    partial class App
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TabPage office_tab;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pnl_super = new System.Windows.Forms.Panel();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_market = new System.Windows.Forms.Button();
            this.bnt_schools = new System.Windows.Forms.Button();
            this.pnl_schools = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnl_several = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.moverFrame = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            office_tab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            office_tab.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.pnl_schools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moverFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(office_tab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 45);
            this.tabControl1.Location = new System.Drawing.Point(-1, 30);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 521);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // office_tab
            // 
            office_tab.AutoScroll = true;
            office_tab.BackColor = System.Drawing.Color.Black;
            office_tab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            office_tab.Controls.Add(this.pnl_header);
            office_tab.Controls.Add(this.pnl_schools);
            office_tab.Controls.Add(this.pnl_super);
            office_tab.Controls.Add(this.pnl_several);
            office_tab.Controls.Add(this.pnl_main);
            office_tab.Cursor = System.Windows.Forms.Cursors.Hand;
            office_tab.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            office_tab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            office_tab.Location = new System.Drawing.Point(4, 4);
            office_tab.Name = "office_tab";
            office_tab.Padding = new System.Windows.Forms.Padding(3);
            office_tab.Size = new System.Drawing.Size(992, 468);
            office_tab.TabIndex = 0;
            office_tab.Text = "Despacho";
            // 
            // pnl_super
            // 
            this.pnl_super.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_super.BackColor = System.Drawing.Color.BurlyWood;
            this.pnl_super.Location = new System.Drawing.Point(0, 74);
            this.pnl_super.Name = "pnl_super";
            this.pnl_super.Size = new System.Drawing.Size(994, 399);
            this.pnl_super.TabIndex = 3;
            this.pnl_super.Visible = false;
            this.pnl_super.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pnl_main
            // 
            this.pnl_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_main.Location = new System.Drawing.Point(-1, 75);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(995, 395);
            this.pnl_main.TabIndex = 1;
            this.pnl_main.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_main_Paint);
            // 
            // pnl_header
            // 
            this.pnl_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_header.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnl_header.Controls.Add(this.button1);
            this.pnl_header.Controls.Add(this.bnt_schools);
            this.pnl_header.Controls.Add(this.btn_market);
            this.pnl_header.Location = new System.Drawing.Point(-1, -1);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(998, 79);
            this.pnl_header.TabIndex = 0;
            this.pnl_header.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_header_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.button1.Location = new System.Drawing.Point(807, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 62);
            this.button1.TabIndex = 6;
            this.button1.Text = "Varios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_several);
            // 
            // btn_market
            // 
            this.btn_market.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_market.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_market.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.btn_market.Location = new System.Drawing.Point(312, 8);
            this.btn_market.Name = "btn_market";
            this.btn_market.Size = new System.Drawing.Size(383, 62);
            this.btn_market.TabIndex = 5;
            this.btn_market.Text = "Super Mercados";
            this.btn_market.UseVisualStyleBackColor = true;
            this.btn_market.Click += new System.EventHandler(this.btn_market_Click);
            // 
            // bnt_schools
            // 
            this.bnt_schools.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bnt_schools.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnt_schools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.bnt_schools.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.bnt_schools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnt_schools.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.bnt_schools.ForeColor = System.Drawing.Color.Black;
            this.bnt_schools.Location = new System.Drawing.Point(19, 8);
            this.bnt_schools.Name = "bnt_schools";
            this.bnt_schools.Size = new System.Drawing.Size(179, 62);
            this.bnt_schools.TabIndex = 4;
            this.bnt_schools.Text = "Escuelas";
            this.bnt_schools.UseVisualStyleBackColor = true;
            this.bnt_schools.Click += new System.EventHandler(this.bnt_schools_Click);
            // 
            // pnl_schools
            // 
            this.pnl_schools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_schools.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnl_schools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_schools.Controls.Add(this.splitContainer1);
            this.pnl_schools.Location = new System.Drawing.Point(-2, 75);
            this.pnl_schools.Name = "pnl_schools";
            this.pnl_schools.Size = new System.Drawing.Size(993, 394);
            this.pnl_schools.TabIndex = 0;
            this.pnl_schools.Visible = false;
            this.pnl_schools.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_schools_Paint);
            // 
            // tabPage2
            // 
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(992, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procesos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnl_several
            // 
            this.pnl_several.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_several.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnl_several.Location = new System.Drawing.Point(-5, 75);
            this.pnl_several.Name = "pnl_several";
            this.pnl_several.Size = new System.Drawing.Size(1001, 395);
            this.pnl_several.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(10, 9);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(974, 374);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rutas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnMinimize.Location = new System.Drawing.Point(936, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 30);
            this.btnMinimize.TabIndex = 18;
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
            this.btnExit.Location = new System.Drawing.Point(970, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 16;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // moverFrame
            // 
            this.moverFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moverFrame.BackColor = System.Drawing.Color.Black;
            this.moverFrame.Location = new System.Drawing.Point(-1, 0);
            this.moverFrame.Name = "moverFrame";
            this.moverFrame.Size = new System.Drawing.Size(1009, 30);
            this.moverFrame.TabIndex = 17;
            this.moverFrame.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(311, 322);
            this.dataGridView1.TabIndex = 2;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 549);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.moverFrame);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "App";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            office_tab.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_schools.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moverFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnl_header;
        
        private System.Windows.Forms.Panel pnl_super;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.Panel pnl_schools;
        private System.Windows.Forms.Button btn_market;
        private System.Windows.Forms.Button bnt_schools;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnl_several;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox moverFrame;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

