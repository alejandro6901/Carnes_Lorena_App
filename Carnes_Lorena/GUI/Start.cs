using System;
using System.Windows.Forms;
using Entities;
using BO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class Start : Form
    {


        public Start()
        {

            InitializeComponent();


        }


        private int TogMove;
        private int MValX;
        private int MValY;
        public Form Login { get; set; }




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
            // Login.Visible = true;
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void moverFrame_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void moverFrame_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void moverFrame_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {

                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);

            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            Schools s = new Schools();
            s.Named = named.Text;
            s.Ubication = ubication.Text;
            s.Manager1 = contact1.Text;
            s.Manager2 = contact2.Text;
            s.Phone1 = Int32.Parse(tel1.Text);
            s.Phone2 = Int32.Parse(tel2.Text);
            s.Mail = mail.Text;
            s.Notes = notes.Text;
            s.Id_Route = Int32.Parse(idroute.Text);
            SchoolsBO sbo = new SchoolsBO();
            if (sbo.RegisterSchool(s))
            {
                MessageBox.Show("hola");
            }

        }

        private void testgrid_Click(object sender, EventArgs e)
        {
            SchoolsBO sbo = new SchoolsBO();
            tbData.DataSource = sbo.GetAllSchools();
            tbData.DataMember = "schools";
        }

        private void tel1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contact1_TextChanged(object sender, EventArgs e)
        {

        }

        private void named_TextChanged(object sender, EventArgs e)
        {

        }

        private void moveFrame_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void moveFrame_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void moveFrame_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void Start_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }

        private void order_Click(object sender, EventArgs e)
        {
            Orders o = new Orders();
            o.Id_Client = Int32.Parse(id_client.Text);
            o.Id_Product = id_product.Text;
            o.Quantity = Double.Parse(quantity.Text);
            o.Notes = order_notes.Text;
            o.Client = client.Text;
            o.Product = product.Text;
            o.Created = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
            OrdersBO obo = new OrdersBO();
            if (obo.RegisterOrder(o))
            {
                MessageBox.Show("hola");
            }
        }

        private void see_orders_Click(object sender, EventArgs e)
        {
            OrdersBO sbo = new OrdersBO();
            dataGridView2.DataSource = sbo.GetAllOrders();
            dataGridView2.DataMember = "orders";
        }

        private void show_Click(object sender, EventArgs e)
        {
            OrdersBO obo = new OrdersBO();
            Orders o = new Orders();
            o = obo.ShowOrderById(Int32.Parse(search.Text));
            if (o.Id > 0)
            {
                txt_id_order.Text = o.Id.ToString();
                id_client.Text = o.Id_Client.ToString();
                id_product.Text = o.Id_Product.ToString();
                quantity.Text = o.Quantity.ToString();
                order_notes.Text = o.Notes;
                client.Text = o.Client;
                product.Text = o.Product;
                created.Text = o.Created;
                if (o.State == 1)
                {
                    checkstate.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("No se encuentran órdenes de cliente");
            }
        }

        private void btn_by_client_Click(object sender, EventArgs e)
        {
            OrdersBO sbo = new OrdersBO();
            Orders o = new Orders();
            o = sbo.ShowOrderByClient(search_by_client.Text);
            if (o.Id > 0)
            {
                id_client.Text = o.Id_Client.ToString();
                id_product.Text = o.Id_Product.ToString();
                quantity.Text = o.Quantity.ToString() + " KG";
                order_notes.Text = o.Notes;
                client.Text = o.Client;
                product.Text = o.Product;
                if (o.State == 1)
                {
                    checkstate.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("No se encuentran órdenes de cliente");
            }
        }

        private void editar_Click(object sender, EventArgs e)
        {
            DateTime iDate;
            iDate = dateTimePicker1.Value.Date;
            Orders o = new Orders();
            o.Id = Int32.Parse(txt_id_order.Text);
            o.Id_Client = Int32.Parse(id_client.Text);
            o.Id_Product = id_product.Text;
            o.Quantity = Double.Parse(quantity.Text);
            o.Notes = order_notes.Text;
            o.Client = client.Text;
            o.Product = product.Text;
            o.Created = iDate.ToString();
            if (checkstate.Checked)
            {
                o.State = 1;
            }
            OrdersBO obo = new OrdersBO();
            int id_order = obo.UpdateOrder(o);
            if (id_order > 0)
            {
                o = obo.ShowOrderById(id_order);
                if (o.Id > 0)
                {
                    txt_id_order.Text = o.Id.ToString();
                    id_client.Text = o.Id_Client.ToString();
                    id_product.Text = o.Id_Product.ToString();
                    quantity.Text = o.Quantity.ToString();
                    order_notes.Text = o.Notes;
                    client.Text = o.Client;
                    product.Text = o.Product;
                    created.Text = o.Created;
                    if (o.State == 1)
                    {
                        checkstate.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("No se encuentran órdenes de cliente");
                }
            }
        }
    }
}
