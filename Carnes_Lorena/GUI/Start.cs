using System;
using System.Windows.Forms;
using Entities;
using BO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace GUI
{
    public partial class Start : Form
    {

        SchoolsBO scbo;
        SupermarketBO spbo;
        SeveralsBO svbo;

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
            //s.Id_Route = Int32.Parse(idroute.Text);
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
            Load_Routes();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.MinDate = DateTime.Now; //disable past days
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
            if (rbtDespacho.Checked)
            {
                o.Department = 0;
            }
            else
            {
                o.Department = 1;
            }
            o.Created = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
            o.Delivery = dateTimePicker1.Value.ToShortDateString();
            OrdersBO obo = new OrdersBO();
            if (obo.RegisterOrder(o))
            {
                MessageBox.Show("hola");
            }
        }

        private void see_orders_Click(object sender, EventArgs e)
        {
            OrdersBO obo = new OrdersBO();
            dataGridView2.DataSource = obo.GetAllOrders();
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
                see_delivery.Text = o.Delivery;
                if (o.Department == 0)
                {
                    rbtDespacho.Checked = true;
                }
                else
                {
                    rbtProcesos.Checked = true;
                }
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
                quantity.Text = o.Quantity.ToString();
                order_notes.Text = o.Notes;
                client.Text = o.Client;
                product.Text = o.Product;
                created.Text = o.Created;
                see_delivery.Text = o.Delivery;
                if (o.Department == 0)
                {
                    rbtDespacho.Checked = true;
                }
                else
                {
                    rbtProcesos.Checked = true;
                }
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
            Orders o = new Orders();
            o.Id = Int32.Parse(txt_id_order.Text);
            o.Id_Client = Int32.Parse(id_client.Text);
            o.Id_Product = id_product.Text;
            o.Quantity = Double.Parse(quantity.Text);
            o.Notes = order_notes.Text;
            o.Client = client.Text;
            o.Product = product.Text;
            o.Created = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
            o.Delivery = dateTimePicker1.Value.ToShortDateString();

            if (checkstate.Checked)
            {
                o.State = 1;
            }
            if (rbtDespacho.Checked)
            {
                o.Department = 0;
            }
            else
            {
                o.Department = 1;
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void created_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void checkstate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void see_delivery_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void btnVerDespacho_Click(object sender, EventArgs e)
        {
            OrdersBO obo = new OrdersBO();
            dataGridView2.DataSource = obo.GetAllOrdersOfDispatch();
            dataGridView2.DataMember = "orders";
        }

        private void btnVerProcesos_Click(object sender, EventArgs e)
        {
            OrdersBO obo = new OrdersBO();
            dataGridView2.DataSource = obo.GetAllOrdersOfProcess();
            dataGridView2.DataMember = "orders";
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_client_Click(object sender, EventArgs e)
        {
            //verificar tipo de usuario
            //llamar método encargado del tipo
            if (rbn_school.Checked)
            {
                if (Save_School())
                {
                    MessageBox.Show("Cliente guardado con éxito");
                }
                else
                {
                    MessageBox.Show("Error al guardar cliente");
                }
            }
            else if (rbn_super.Checked)
            {
                if (Save_Super())
                {
                    MessageBox.Show("Cliente guardado con éxito");
                }
                else
                {
                    MessageBox.Show("Error al guardar cliente");
                }
            }
            else
            {
                if (Save_Several())
                {
                    MessageBox.Show("Cliente guardado con éxito");
                }
                else
                {
                    MessageBox.Show("Error al guardar cliente");
                }
            }
        }

        public bool Save_School()
        {
            Schools s = new Schools();
            s.Named = txt_name.Text;
            s.Ubication = txt_ubication.Text;
            s.Manager1 = txt_manager1.Text;
            s.Manager2 = txt_manager2.Text;
            s.Phone1 = Int32.Parse(txt_tel1.Text);
            s.Phone2 = Int32.Parse(txt_tel2.Text);
            s.Mail = txt_mail.Text;
            s.Notes = rch_notes.Text;
            s.Route = cbx_routes.SelectedItem.ToString();
            SchoolsBO sbo = new SchoolsBO();
            return sbo.RegisterSchool(s);
        }

        public bool Save_Super()
        {
            Supermarkets s = new Supermarkets();
            s.Named = txt_name.Text;
            s.Ubication = txt_ubication.Text;
            s.Manager1 = txt_manager1.Text;
            s.Manager2 = txt_manager2.Text;
            s.Phone1 = Int32.Parse(txt_tel1.Text);
            s.Phone2 = Int32.Parse(txt_tel2.Text);
            s.Mail = txt_mail.Text;
            s.Notes = rch_notes.Text;

            SupermarketBO sbo = new SupermarketBO();
            return sbo.RegisterSupermarket(s);
        }

        public bool Save_Several()
        {
            Severals s = new Severals();
            s.Named = txt_name.Text;
            s.Phone1 = Int32.Parse(txt_tel1.Text);
            s.Phone2 = Int32.Parse(txt_tel2.Text);

            SeveralsBO sbo = new SeveralsBO();
            return sbo.RegisterSeveral(s);
        }

        /**
         * 
         * */
        public void Load_Routes()
        {
            RouteBO rbo = new RouteBO();
            List<Routes> rs = rbo.Load_Routes();
            foreach (Routes r in rs)
            {
                cbx_routes.Items.Add(r.Named);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SchoolsBO sbo = new SchoolsBO();
            dtgw_clients.DataSource = sbo.GetAllSchools();
            dtgw_clients.DataMember = "schools";
        }

        private void btn_all_clients_Click(object sender, EventArgs e)
        {
            CustomersBO cbo = new CustomersBO();
            dtgw_clients.DataSource = cbo.GetAllCustomers();
            dtgw_clients.DataMember = "customers";
        }

        private void btn_search_name_Click(object sender, EventArgs e)
        {
            CustomersBO cbo = new CustomersBO();
            string name = txt_client_name.Text;
            int type = cbo.GetByName(name);
            if (type == 1)
            {
                dtgw_clients.DataSource = new SchoolsBO().GetByName(name);
                //dtgw_clients.DataMember = "schools";
            }
            else if (type == 2)
            {
                dtgw_clients.DataSource = new SupermarketBO().GetByName(name);
            }
            else
            {
                dtgw_clients.DataSource = new SeveralsBO().GetByName(name);
            }
        }


        private void btn_search_supers_Click(object sender, EventArgs e)
        {
            SupermarketBO sbo = new SupermarketBO();
            dtgw_clients.DataSource = sbo.GetAllSupermarkets();
            dtgw_clients.DataMember = "supermarkets";
        }

        private void btn_search_severals_Click(object sender, EventArgs e)
        {
            SeveralsBO sbo = new SeveralsBO();
            dtgw_clients.DataSource = sbo.GetAllSeverals();
            dtgw_clients.DataMember = "severals";
        }
    }
}