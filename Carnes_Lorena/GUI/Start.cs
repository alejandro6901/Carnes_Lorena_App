using System;
using System.Windows.Forms;
using Entities;
using BO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Data;

namespace GUI
{
    public partial class Start : Form
    {

        CustomersBO cbo;
        SchoolsBO scbo;
        SupermarketBO spbo;
        SeveralsBO svbo;
        ProductBO pbo;
        OrdersBO obo;

        string gb_client_name;  //para búsqueda de cliente por click en datagridview 

        public Start()
        {

            InitializeComponent();
            gb_client_name = "";
        }


        private int TogMove;
        private int MValX;
        private int MValY;
        public Form Login { get; set; }


        private void AutocompleteClientText()
        {
            List<string> list_clients = Get_Clients_Name();
            txt_client_ord.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();
            accl.AddRange(list_clients.ToArray());
            txt_client_ord.AutoCompleteCustomSource = accl;
            txt_client_ord.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AutocompleteProductsCode()
        {
            List<string> list_products = Get_Products_Code();
            txt_code_ord.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();
            accl.AddRange(list_products.ToArray());
            txt_code_ord.AutoCompleteCustomSource = accl;
            txt_code_ord.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AutocompleteProductsName()
        {
            List<string> list_products = Get_Products_Name();
            txt_prod_ord.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();
            accl.AddRange(list_products.ToArray());
            txt_prod_ord.AutoCompleteCustomSource = accl;
            txt_prod_ord.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private List<string> Get_Clients_Name()
        {
            cbo = new CustomersBO();

            DataTable tableList = cbo.Get_Clients_Name();
            List<string> list = new List<string>();

            for (int i = 0; i < tableList.Rows.Count; i++)
            {
                list.Add(tableList.Rows[i]["named"].ToString());
            }
            return list;

        }

        private List<string> Get_Products_Code()
        {
            pbo = new ProductBO();

            DataTable tableList = pbo.Get_Products_Code();
            List<string> list = new List<string>();

            for (int i = 0; i < tableList.Rows.Count; i++)
            {
                list.Add(tableList.Rows[i]["code"].ToString());
            }
            return list;

        }

        private List<string> Get_Products_Name()
        {
            pbo = new ProductBO();

            DataTable tableList = pbo.Get_Products_Name();
            List<string> list = new List<string>();

            for (int i = 0; i < tableList.Rows.Count; i++)
            {
                list.Add(tableList.Rows[i]["named"].ToString());
            }
            return list;

        }

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

            dtp_reminder_ord.Format = DateTimePickerFormat.Short;
            dtp_reminder_ord.Value = DateTime.Today;
            dtp_reminder_ord.MinDate = DateTime.Now; //disable past days

            dtp_delivery_ord.Format = DateTimePickerFormat.Short;
            dtp_delivery_ord.Value = DateTime.Today;
            dtp_delivery_ord.MinDate = DateTime.Now; //disable past days

            AutocompleteClientText();
            AutocompleteProductsCode();
            AutocompleteProductsName();
            GetLastId();

            scbo = new SchoolsBO();
            dtgw_orders_sch.DataSource = scbo.GetAllSchools();
            dtgw_orders_sch.DataMember = "schools";

            spbo = new SupermarketBO();
            dtgw_orders_supers.DataSource = spbo.GetAllSupermarkets();
            dtgw_orders_supers.DataMember = "supermarkets";

            svbo = new SeveralsBO();
            dtgw_orders_sev.DataSource = svbo.GetAllSeverals();
            dtgw_orders_sev.DataMember = "severals";

            pbo = new ProductBO();
            dtgw_orders_products.DataSource = pbo.GetAllProducts();
            dtgw_orders_products.DataMember = "products";
        }

        public void GetLastId()
        {
            obo = new OrdersBO();
            lblIdOrder.Text = (obo.GetLastId() + 1).ToString();
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
            s.Notes = rch_client_notes.Text;
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
            s.Notes = rch_client_notes.Text;

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
            scbo = new SchoolsBO();
            dtgw_clients.DataSource = scbo.GetAllSchools();
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
            Get_Client_By_Name(txt_client_name.Text);
        }


        private void btn_search_supers_Click(object sender, EventArgs e)
        {
            spbo = new SupermarketBO();
            dtgw_clients.DataSource = spbo.GetAllSupermarkets();
            dtgw_clients.DataMember = "supermarkets";
        }

        private void btn_search_severals_Click(object sender, EventArgs e)
        {
            svbo = new SeveralsBO();
            dtgw_clients.DataSource = svbo.GetAllSeverals();
            dtgw_clients.DataMember = "severals";
        }

        private void btn_save_product_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Code = txt_prod_code.Text;
            p.Named = txt_prod_name.Text;
            p.Notes = rch_product_notes.Text;
            ProductBO pbo = new ProductBO();
            if (pbo.RegisterProduct(p))
            {
                MessageBox.Show("Producto registrado con éxito");
            }
            else
            {
                MessageBox.Show("Ocurrió un error en registro de producto");
            }
        }

        private void btn_all_products_Click(object sender, EventArgs e)
        {
            pbo = new ProductBO();
            dtgw_products.DataSource = pbo.GetAllProducts();
            dtgw_products.DataMember = "products";
        }

        private void btn_search_product_Click(object sender, EventArgs e)
        {
            dtgw_products.DataSource = new ProductBO().GetByName(txt_search_prod.Text);
        }

        private void btn_search_code_Click(object sender, EventArgs e)
        {
            dtgw_products.DataSource = new ProductBO().GetByCode(txt_search_code.Text);
        }

        private void dtgw_clients_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgw_clients.SelectedCells.Count > 0)
            {
                int selectedrowindex = dtgw_clients.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dtgw_clients.Rows[selectedrowindex];

                gb_client_name = Convert.ToString(selectedRow.Cells["named"].Value);

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Get_Client_By_Name(gb_client_name);
        }

        private void Get_Client_By_Name(string name)
        {
            CustomersBO cbo = new CustomersBO();
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

        private void txt_code_ord_Leave(object sender, EventArgs e)
        {
            pbo = new ProductBO();
            string[] result = pbo.Get_Product_Name(txt_code_ord.Text).Split('%');

            txt_prod_ord.Text = result[0];
            lblIdProduct.Text = result[1];
        }

        private void txt_prod_ord_Leave(object sender, EventArgs e)
        {
            pbo = new ProductBO();
            string[] result = pbo.Get_Code_By_Name(txt_prod_ord.Text).Split('%');
            txt_code_ord.Text = result[0];
            lblIdProduct.Text = result[1];
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            if (VerifyDates())
            {
                Orders o = new Orders();
                o.Id_Client = Int32.Parse(lblIdClient.Text);
                o.Id_Product = lblIdProduct.Text;
                o.Quantity = Double.Parse(txt_quantity_ord.Text);
                o.Notes = rch_notes_ord.Text;
                o.Client = txt_client_ord.Text;
                o.Product = txt_prod_ord.Text;
                if (rbtDespacho.Checked)
                {
                    o.Department = 0;
                }
                else
                {
                    o.Department = 1;
                }
                o.Created = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
                o.Delivery = dtp_delivery_ord.Value.ToShortDateString();
                o.Reminder = dtp_reminder_ord.Value.ToShortDateString();
                OrdersBO obo = new OrdersBO();
                if (obo.RegisterOrder(o))
                {
                    MessageBox.Show("Pedido registrado correctamente");
                }
            }
            else
            {
                MessageBox.Show("EL RECORDATORIO NO PUEDE SER MAYOR A LA FECHA DE ENTREGA");
            }
        }

        public bool VerifyDates()
        {
            DateTime dt1 = dtp_reminder_ord.Value;
            DateTime dt2 = dtp_delivery_ord.Value;
            int result = DateTime.Compare(dt1, dt2);
            if (result < 0)
            {
                return true;
            }
            else if (result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txt_client_ord_Leave(object sender, EventArgs e)
        {
            cbo = new CustomersBO();
            string name = cbo.GetIdByName(txt_client_ord.Text).ToString();
            lblIdClient.Text = name;
        }
    }
}