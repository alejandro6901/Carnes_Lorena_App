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
    public partial class Login : Form
    {
        private int TogMove;
        private int MValX;
        private int MValY;
        private Start log;
        public Form LoginFrm { get; set; }

        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
      
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void moveFrame_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void moveFrame_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {

                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);

            }
        }

        private void moveFrame_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            log = new Start()
            {
                
              Login = this
            };
           log.Show();

            this.Hide();
        }
    }
}
