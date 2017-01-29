using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
           
        }


        private int TogMove;
        private int MValX;
        private int MValY;




        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_schools_Paint(object sender, PaintEventArgs e)
        {

        }

 

  
        private void btn_several(object sender, EventArgs e)
        {
            pnl_main.Visible = false;
            pnl_schools.Visible = false;
            pnl_super.Visible = false;
            pnl_several.Visible = true;


        }

        private void bnt_schools_Click(object sender, EventArgs e)
        {
            pnl_main.Visible = false;
            pnl_super.Visible = false;
            pnl_schools.Visible = true;
        }

        private void btn_market_Click(object sender, EventArgs e)
        {

            pnl_schools.Visible = false;
            pnl_main.Visible = false;
            pnl_super.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pnl_header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        
            this.Close(); 
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
