namespace GUI
{
    partial class Start
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bnt_schools = new System.Windows.Forms.Button();
            this.btn_market = new System.Windows.Forms.Button();
            this.pnl_schools = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_super = new System.Windows.Forms.Panel();
            this.pnl_several = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.moverFrame = new System.Windows.Forms.PictureBox();
            office_tab = new System.Windows.Forms.TabPage();
            office_tab.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.pnl_schools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moverFrame)).BeginInit();
            this.SuspendLayout();
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
            office_tab.Cursor = System.Windows.Forms.Cursors.Hand;
            office_tab.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            office_tab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            office_tab.Location = new System.Drawing.Point(4, 49);
            office_tab.Name = "office_tab";
            office_tab.Padding = new System.Windows.Forms.Padding(3);
            office_tab.Size = new System.Drawing.Size(1007, 497);
            office_tab.TabIndex = 0;
            office_tab.Text = "Despacho";
            // 
            // pnl_header
            // 
            this.pnl_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.pnl_header.Controls.Add(this.button1);
            this.pnl_header.Controls.Add(this.bnt_schools);
            this.pnl_header.Controls.Add(this.btn_market);
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(201, 496);
            this.pnl_header.TabIndex = 0;
            this.pnl_header.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_header_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(0, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 98);
            this.button1.TabIndex = 6;
            this.button1.Text = "Varios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_several);
            // 
            // bnt_schools
            // 
            this.bnt_schools.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bnt_schools.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bnt_schools.FlatAppearance.BorderSize = 0;
            this.bnt_schools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.bnt_schools.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.bnt_schools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnt_schools.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.bnt_schools.ForeColor = System.Drawing.Color.White;
            this.bnt_schools.Location = new System.Drawing.Point(0, 12);
            this.bnt_schools.Name = "bnt_schools";
            this.bnt_schools.Size = new System.Drawing.Size(203, 103);
            this.bnt_schools.TabIndex = 4;
            this.bnt_schools.Text = "Escuelas";
            this.bnt_schools.UseVisualStyleBackColor = true;
            this.bnt_schools.Click += new System.EventHandler(this.bnt_schools_Click);
            // 
            // btn_market
            // 
            this.btn_market.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_market.BackColor = System.Drawing.Color.Transparent;
            this.btn_market.FlatAppearance.BorderSize = 0;
            this.btn_market.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_market.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_market.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_market.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.btn_market.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_market.Location = new System.Drawing.Point(3, 110);
            this.btn_market.Name = "btn_market";
            this.btn_market.Size = new System.Drawing.Size(200, 114);
            this.btn_market.TabIndex = 5;
            this.btn_market.Text = "Super Mercados";
            this.btn_market.UseVisualStyleBackColor = false;
            this.btn_market.Click += new System.EventHandler(this.btn_market_Click);
            // 
            // pnl_schools
            // 
            this.pnl_schools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_schools.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnl_schools.Controls.Add(this.splitContainer1);
            this.pnl_schools.Location = new System.Drawing.Point(197, 0);
            this.pnl_schools.Name = "pnl_schools";
            this.pnl_schools.Size = new System.Drawing.Size(806, 497);
            this.pnl_schools.TabIndex = 0;
            this.pnl_schools.Visible = false;
            this.pnl_schools.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_schools_Paint);
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(804, 478);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::GUI.Properties.Resources.remove;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(8, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 36);
            this.button3.TabIndex = 49;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::GUI.Properties.Resources.add1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(194, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 36);
            this.button2.TabIndex = 47;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 2);
            this.label2.TabIndex = 48;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Coral;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(8, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(241, 365);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.TabStop = false;
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(66, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rutas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnl_super
            // 
            this.pnl_super.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_super.BackColor = System.Drawing.Color.BurlyWood;
            this.pnl_super.Location = new System.Drawing.Point(197, -6);
            this.pnl_super.Name = "pnl_super";
            this.pnl_super.Size = new System.Drawing.Size(814, 523);
            this.pnl_super.TabIndex = 3;
            this.pnl_super.Visible = false;
            this.pnl_super.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pnl_several
            // 
            this.pnl_several.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_several.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnl_several.Location = new System.Drawing.Point(197, -9);
            this.pnl_several.Name = "pnl_several";
            this.pnl_several.Size = new System.Drawing.Size(810, 512);
            this.pnl_several.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(office_tab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 45);
            this.tabControl1.Location = new System.Drawing.Point(-7, 27);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 550);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1007, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procesos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnl_main
            // 
            this.pnl_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_main.Location = new System.Drawing.Point(-3, 21);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1025, 504);
            this.pnl_main.TabIndex = 1;
            this.pnl_main.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_main_Paint);
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
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 572);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.moverFrame);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnl_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "App";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            office_tab.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.pnl_schools.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moverFrame)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}

