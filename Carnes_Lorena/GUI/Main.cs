using BO;
using Entities;
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
    public partial class Main : Form
    {
        School school;
        Supermarket super;
        Several several;
        ProductBO pbo;
        OrderBO obo;
        RouteBO rbo;
        CustomerBO cbo;
        SchoolBO scbo;
        SupermarketBO spbo;
        SeveralBO svbo;
        DataTable dtadd;
        DataTable dtItem;
        DataTable dtRemItem;
        DataTable dtRemItemPro;
        DataTable dtDelivItem;
        DataTable dtDelivItemPro;
        LinkedList<Item> ordersList;
        List<string> list_clients;
        List<string> list_product_codes;
        List<string> list_products;
        List<int> ordersReminder;
        List<int> ordersReminderPro;
        LinkedList<Item> itemsReminder;
        LinkedList<Item> itemsReminderPro;
        List<int> ordersDeliveries;
        List<int> ordersDeliveriesPro;
        LinkedList<Item> itemsDeliveries;
        LinkedList<Item> itemsDeliveriesPro;

        int reminderDispatch;
        int deliveryDispatch;
        int reminderProcesses;
        int deliveryProcesses;

        public Main()
        {
            InitializeComponent();
            reminderDispatch = 0;
            deliveryDispatch = 0;
            reminderProcesses = 0;
            deliveryProcesses = 0;
        }


        /**
         * Gets all clients and put them on each tab
         * */
        private void RefreshAllOnStart()
        {
            GetAllCustomers();
            GetAllSchools();
            GetAllSupermarkets();
            GetAllSeverals();
            GetAllProducts();
            RefreshAllOrders();
        }
        /**
         * Method that gets all customers
         * */
        private void GetAllCustomers()
        {
            cbo = new CustomerBO();
            dtgw_clients_all.DataSource = cbo.GetAllCustomers();
            dtgw_clients_all.DataMember = "customers";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tabControl4.TabPages.Remove(tabPage21);
            ordersList = new LinkedList<Item>();
            dtadd = new DataTable();
            dtadd.Columns.Add("N° ORDEN");
            dtadd.Columns.Add("CÓDIGO");
            dtadd.Columns.Add("PRODUCTO");
            dtadd.Columns.Add("CANTIDAD");
            dtadd.Columns.Add("NOTAS");

            RefreshAllOnStart();
            GetAllRoutes();
            GetTodayRemindersDispatch();
            GetTodayRemindersProcesses();
            GetTodayDeliveriesDispatch();
            GetTodayDeliveriesProcesses();
            //VerifyOrdersQuant();
            //VerifyOrdersQuantPro();

            AutocompleteClientText();
            AutocompleteProductsCode();
            AutocompleteProductsName();

            Load_Routes();
            GetLastId();
            pnl_features.Visible = false;
            panel1.Visible = false;
            lblIdClient.Visible = false;
            lblIdProduct.Visible = false;
            lblClientType.Visible = false;

            dtp_reminder_ord.Format = DateTimePickerFormat.Short;
            dtp_reminder_ord.Value = DateTime.Today;
            dtp_reminder_ord.MinDate = DateTime.Now; //disable past days

            dtp_delivery_ord.Format = DateTimePickerFormat.Short;
            dtp_delivery_ord.Value = DateTime.Today;
            dtp_delivery_ord.MinDate = DateTime.Now; //disable past days

            btnRemBack.Enabled = false;
            btnDelivBack.Enabled = false;
            btnRemProBack.Enabled = false;
            btnDelivProBack.Enabled = false;
        }

        private void CreateDtItemCol()
        {
            dtItem = new DataTable();
            dtItem.Columns.Add("N° ORDEN");
            dtItem.Columns.Add("CÓDIGO");
            dtItem.Columns.Add("PRODUCTO");
            dtItem.Columns.Add("KG");
        }

        private void CreateDtRemItemCol()
        {
            dtRemItem = new DataTable();
            dtRemItem.Columns.Add("CÓDIGO");
            dtRemItem.Columns.Add("PRODUCTO");
            dtRemItem.Columns.Add("KG");
        }

        private void CreateDtRemItemProCol()
        {
            dtRemItemPro = new DataTable();
            dtRemItemPro.Columns.Add("CÓDIGO");
            dtRemItemPro.Columns.Add("PRODUCTO");
            dtRemItemPro.Columns.Add("KG");
        }

        private void CreateDtDelivItemCol()
        {
            dtDelivItem = new DataTable();
            dtDelivItem.Columns.Add("CÓDIGO");
            dtDelivItem.Columns.Add("PRODUCTO");
            dtDelivItem.Columns.Add("KG");
        }

        private void CreateDtDelivItemProCol()
        {
            dtDelivItemPro = new DataTable();
            dtDelivItemPro.Columns.Add("CÓDIGO");
            dtDelivItemPro.Columns.Add("PRODUCTO");
            dtDelivItemPro.Columns.Add("KG");
        }

        private void CreateDtProdCol()
        {
            dtItem = new DataTable();
            dtItem.Columns.Add("CÓDIGO");
            dtItem.Columns.Add("NOMBRE");
            dtItem.Columns.Add("NOTA");
        }


        private void AutocompleteClientText()
        {
            list_clients = Get_Clients_Name();

            txt_client_ord.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_client_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_school_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_super_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_several_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();
            accl.AddRange(list_clients.ToArray());

            txt_client_ord.AutoCompleteCustomSource = accl;
            txt_client_name.AutoCompleteCustomSource = accl;
            txt_school_name.AutoCompleteCustomSource = accl;
            txt_super_name.AutoCompleteCustomSource = accl;
            txt_several_name.AutoCompleteCustomSource = accl;

            txt_client_ord.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_client_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_school_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_super_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_several_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AutocompleteProductsCode()
        {
            list_product_codes = Get_Products_Code();

            txt_code_ord.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_search_code.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();
            accl.AddRange(list_product_codes.ToArray());
            txt_code_ord.AutoCompleteCustomSource = accl;
            txt_search_code.AutoCompleteCustomSource = accl;
            txt_code_ord.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_search_code.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AutocompleteProductsName()
        {
            list_products = Get_Products_Name();

            txt_prod_ord.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_search_prod.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();
            accl.AddRange(list_products.ToArray());

            txt_prod_ord.AutoCompleteCustomSource = accl;
            txt_search_prod.AutoCompleteCustomSource = accl;
            txt_prod_ord.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_search_prod.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private List<string> Get_Clients_Name()
        {
            cbo = new CustomerBO();

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

        /**
         * Method that gets client by name depending on name
         * */
        private DataTable Get_Client_By_Name(string name)
        {
            cbo = new CustomerBO();

            int type = cbo.GetByName(name);
            if (type == 1)
            {
                return new SchoolBO().GetByName(name);
            }
            else if (type == 2)
            {
                return new SupermarketBO().GetByName(name);
            }
            else
            {
                return new SeveralBO().GetByName(name);
            }
        }

        private void rbn_school_CheckedChanged(object sender, EventArgs e)
        {
            pnl_features.Visible = true;
            pnl_routes.Visible = true;
        }

        private void rbn_super_CheckedChanged(object sender, EventArgs e)
        {
            pnl_features.Visible = true;
            pnl_routes.Visible = false;
        }

        private void rbn_other_CheckedChanged(object sender, EventArgs e)
        {
            pnl_features.Visible = false;
        }

        private void btn_save_client_Click(object sender, EventArgs e)
        {
            if (rbn_school.Checked)
            {
                if (Save_School())
                {
                    MessageBox.Show("Cliente guardado con éxito");
                    GetAllSchools();
                    GetAllCustomers();
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
                    GetAllSupermarkets();
                    GetAllCustomers();
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
                    GetAllSeverals();
                    GetAllCustomers();
                }
                else
                {
                    MessageBox.Show("Error al guardar cliente");
                }
            }
        }

        public bool Save_School()
        {
            string route = "";
            if (!(txt_name.Text.Trim().Equals("")))
            {
                if (cbx_routes.SelectedItem == null)
                {
                    route = "SIN ASIGNAR";
                }
                else
                {
                    route = cbx_routes.SelectedItem.ToString();
                }
                school = new School();
                school.Named = txt_name.Text.Trim().ToUpper();
                school.Ubication = txt_ubication.Text.Trim().ToUpper();
                school.Manager1 = txt_manager1.Text.Trim().ToUpper();
                school.Manager2 = txt_manager2.Text.Trim().ToUpper();
                school.Phone1 = Int32.Parse(txt_tel1.Text);
                school.Phone2 = Int32.Parse(txt_tel2.Text);
                school.Mail = txt_mail.Text.Trim();
                school.Notes = rch_client_notes.Text.Trim().ToUpper();
                school.Route = route;
                scbo = new SchoolBO();
                return scbo.RegisterSchool(school);

            }
            return false;
        }

        public bool Save_Super()
        {
            if (!(txt_name.Text.Trim().Equals("")))
            {
                super = new Supermarket();
                super.Named = txt_name.Text.Trim().ToUpper();
                super.Ubication = txt_ubication.Text.Trim().ToUpper();
                super.Manager1 = txt_manager1.Text.Trim().ToUpper();
                super.Manager2 = txt_manager2.Text.Trim().ToUpper();
                super.Phone1 = Int32.Parse(txt_tel1.Text);
                super.Phone2 = Int32.Parse(txt_tel2.Text);
                super.Mail = txt_mail.Text.Trim();
                super.Notes = rch_client_notes.Text.Trim().ToUpper();

                spbo = new SupermarketBO();
                return spbo.RegisterSupermarket(super);
            }
            return false;
        }

        public bool Save_Several()
        {
            if (!(txt_name.Text.Trim().Equals("")))
            {
                several = new Several();
                several.Named = txt_name.Text.Trim().ToUpper();
                several.Phone1 = Int32.Parse(txt_tel1.Text);
                several.Phone2 = Int32.Parse(txt_tel2.Text);
                svbo = new SeveralBO();
                return svbo.RegisterSeveral(several);
            }
            return false;
        }

        private void Load_Routes()
        {
            RouteBO rbo = new RouteBO();
            List<Route> rs = rbo.Load_Routes();
            cbx_routes.Items.Clear();
            foreach (Route r in rs)
            {
                cbx_routes.Items.Add(r.Named);
            }
        }

        private void GetAllSchools()
        {
            scbo = new SchoolBO();
            dtgw_clients_schools.DataSource = scbo.GetAllSchools();
            dtgw_clients_schools.DataMember = "schools";
        }

        private void GetAllSupermarkets()
        {
            spbo = new SupermarketBO();
            dtgw_clients_supers.DataSource = spbo.GetAllSupermarkets();
            dtgw_clients_supers.DataMember = "supermarkets";
        }

        private void GetAllSeverals()
        {
            svbo = new SeveralBO();
            dtgw_clients_severals.DataSource = svbo.GetAllSeverals();
            dtgw_clients_severals.DataMember = "severals";
        }

        public void GetLastId()
        {
            obo = new OrderBO();
            lblIdOrder.Text = (obo.GetLastId() + 1).ToString();
        }

        private void btn_search_client_Click(object sender, EventArgs e)
        {
            dtgw_clients_all.DataSource = Get_Client_By_Name(txt_client_name.Text.Trim().ToUpper());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scbo = new SchoolBO();
            dtgw_clients_schools.DataSource = scbo.GetByName(txt_school_name.Text.Trim().ToUpper());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spbo = new SupermarketBO();
            dtgw_clients_supers.DataSource = spbo.GetByName(txt_super_name.Text.Trim().ToUpper());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            svbo = new SeveralBO();
            dtgw_clients_severals.DataSource = svbo.GetByName(txt_several_name.Text.Trim().ToUpper());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetAllSchools();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetAllSupermarkets();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetAllSeverals();
        }

        private void GetAllProducts()
        {
            pbo = new ProductBO();
            dtgw_products.DataSource = pbo.GetAllProducts();
            dtgw_products.DataMember = "products";


        }

        private void btn_search_product_Click(object sender, EventArgs e)
        {
            if (txt_search_prod.Text.Trim().Equals(""))
            {
                MessageBox.Show("INGRESE VALOR DE BÚSQUEDA");
            }
            else
            {
                dtgw_products.DataSource = new ProductBO().GetByName(txt_search_prod.Text.Trim().ToUpper());
            }
        }

        private void btn_search_code_Click(object sender, EventArgs e)
        {
            if (txt_search_code.Text.Trim().Equals(""))
            {
                MessageBox.Show("INGRESE CÓDIGO DE BÚSQUEDA");
            }
            else
            {
                dtgw_products.DataSource = new ProductBO().GetByCode(txt_search_code.Text.Trim().ToUpper());
            }
        }

        private void btn_save_product_Click(object sender, EventArgs e)
        {
            if (!(txt_prod_code.Text.Trim().Equals("")) && !(txt_prod_name.Text.Trim().Equals("")))
            {
                Product p = new Product();
                p.Code = txt_prod_code.Text.Trim().ToUpper();
                p.Named = txt_prod_name.Text.Trim().ToUpper();
                p.Notes = rch_product_notes.Text.Trim().ToUpper();
                ProductBO pbo = new ProductBO();
                if (pbo.RegisterProduct(p))
                {
                    MessageBox.Show("Producto registrado con éxito");
                    GetAllProducts();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error en registro de producto");
                }
            }
            else
            {
                MessageBox.Show("CÓDIGO O NOMBRE NO HAN SIDO INGRESADOS");
            }
        }

        private void btn_all_products_Click(object sender, EventArgs e)
        {
            GetAllProducts();
        }

        private void RefreshAllOrders()
        {
            GetAllOrders();
            GetSchoolOrders();
            GetSupermarketOrders();
            GetSeveralOrders();
        }

        private void GetAllOrders()
        {
            obo = new OrderBO();
            dtgw_orders_all.DataSource = obo.GetAllOrders();
            dtgw_orders_all.DataMember = "orders";
        }

        private void GetSchoolOrders()
        {
            obo = new OrderBO();
            dtgw_orders_sch.DataSource = obo.GetSchoolOrders();
            dtgw_orders_sch.DataMember = "orders";
        }

        private void GetSupermarketOrders()
        {
            obo = new OrderBO();
            dtgw_orders_supers.DataSource = obo.GetSupermarketOrders();
            dtgw_orders_supers.DataMember = "orders";
        }

        private void GetSeveralOrders()
        {
            obo = new OrderBO();
            dtgw_orders_sev.DataSource = obo.GetSeveralOrders();
            dtgw_orders_sev.DataMember = "orders";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GetAllOrders();
        }

        private void btn_confirm_ord_Click(object sender, EventArgs e)
        {
            if (btn_confirm_ord.Text.Equals("CONFIRMAR PEDIDO"))
            {
                panel1.Visible = true;
                btn_confirm_ord.Text = "COMPLETAR";
            }
            else
            {
                panel1.Visible = false;
                if (VerifyDates())
                {
                    //Método que recorra los pedidos y a todos les ponga la fecha de los datetimepicker
                    SetDates();
                    if (obo.RegisterItems(ordersList))
                    {
                        if (obo.RegisterOrder(BuildOrder()))
                        {
                            MessageBox.Show("Pedido registrado correctamente");
                            RefreshAllOrders();
                            GetTodayRemindersDispatch();
                            GetTodayRemindersProcesses();
                            GetTodayDeliveriesDispatch();
                            GetTodayDeliveriesProcesses();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("EL RECORDATORIO NO PUEDE SER MAYOR A LA FECHA DE ENTREGA");
                }
            }
        }

        private Order BuildOrder()
        {
            Order o = new Order();
            o.Num_Order = Int32.Parse(lblIdOrder.Text);
            o.Client = txt_client_ord.Text.Trim().ToUpper();
            o.Client_Type = Int32.Parse(lblClientType.Text);

            if (txt_order_oem.Text.Trim().Equals(""))
            {
                o.Oem = 0;
            }
            else
            {
                o.Oem = Int32.Parse(txt_order_oem.Text.Trim());
            }
            o.Department = SetDepartment();
            o.Created = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
            o.Delivery = dtp_delivery_ord.Value.ToShortDateString();
            o.Reminder = dtp_reminder_ord.Value.ToShortDateString();
            return o;
        }

        public void SetDates()
        {
            int dep = SetDepartment();
            foreach (Item o in ordersList)
            {
                o.Department = dep;
                o.Created = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
                o.Delivery = dtp_delivery_ord.Value.ToShortDateString();
                o.Reminder = dtp_reminder_ord.Value.ToShortDateString();
            }
        }

        public int SetDepartment()
        {
            if (rbn_despacho.Checked)
            {
                return 0;
            }
            else
            {
                return 1;
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

        private void txt_code_ord_Leave(object sender, EventArgs e)
        {

            if (!(txt_code_ord.Text.Trim().Equals("")))
            {
                if (VerifyCode(txt_code_ord.Text.Trim().ToUpper()))
                {
                    pbo = new ProductBO();
                    string[] result = pbo.Get_Product_Name(txt_code_ord.Text.Trim().ToUpper()).Split('%');
                    txt_prod_ord.Text = result[0];
                    lblIdProduct.Text = result[1];
                }
                else
                {
                    MessageBox.Show("CÓDIGO INCORRECTO, DIRÍJASE A LA PESTAÑA PRODUCTOS PARA MODIFICAR SI LO DESEA");
                    txt_code_ord.Text = "";
                }
            }

        }

        private bool VerifyCode(string code)
        {
            foreach (string c in list_product_codes)
            {
                if (c.Equals(code))
                {
                    return true;
                }
            }
            return false;
        }

        private void txt_prod_ord_Leave(object sender, EventArgs e)
        {

            if (!(txt_prod_ord.Text.Trim().Equals("")))
            {
                if (VerifyProduct(txt_prod_ord.Text.Trim().ToUpper()))
                {
                    pbo = new ProductBO();
                    string[] result = pbo.Get_Code_By_Name(txt_prod_ord.Text.Trim().ToUpper()).Split('%');
                    txt_code_ord.Text = result[0];
                    lblIdProduct.Text = result[1];
                }
                else
                {
                    MessageBox.Show("PRODUCTO INCORRECTO, DIRÍJASE A LA PESTAÑA PRODUCTOS PARA MODIFICAR SI LO DESEA");
                    txt_prod_ord.Text = "";
                }
            }
        }

        private bool VerifyProduct(string product)
        {
            foreach (string p in list_products)
            {
                if (p.Equals(product))
                {
                    return true;
                }
            }
            return false;
        }

        private void txt_client_ord_Leave(object sender, EventArgs e)
        {

            if (!(txt_client_ord.Text.Trim().Equals("")))
            {
                if (VerifyClient(txt_client_ord.Text.Trim().ToUpper()))
                {
                    cbo = new CustomerBO();
                    string[] result = cbo.GetIdByName(txt_client_ord.Text.Trim().ToUpper()).Split('%');
                    lblIdClient.Text = result[0];
                    lblClientType.Text = result[1];
                }
                else
                {
                    MessageBox.Show("CLIENTE INCORRECTO, DIRÍJASE A LA PESTAÑA CLIENTES PARA MODIFICAR O AGREGAR SI LO DESEA");
                    txt_client_ord.Text = "";
                }
            }

        }


        private bool VerifyClient(string client)
        {
            foreach (string c in list_clients)
            {
                if (c.Equals(client))
                {
                    return true;
                }
            }
            return false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GetAllSchools();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GetAllSupermarkets();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GetAllSeverals();
        }

        private void btnEditarOrderSev_Click(object sender, EventArgs e)
        {
            tabControl4.SelectTab(tabPage11);
        }

        private bool RegisterRoute(Route r)
        {
            rbo = new RouteBO();
            return rbo.RegisterRoute(r);
        }

        private void btn_add_route_Click(object sender, EventArgs e)
        {
            if (!(txt_route_name.Text.Trim().Equals("")))
            {
                Route r = new Route();
                r.Named = txt_route_name.Text.Trim().ToUpper();
                if (RegisterRoute(r))
                {
                    MessageBox.Show("REGISTRO EXITOSO");
                    GetAllRoutes();
                    Load_Routes();
                }
                else
                {
                    MessageBox.Show("OCURRIÓ ERROR AL GUARDAR RUTA");
                }
            }
            else
            {
                MessageBox.Show("DEBE INGRESAR VALORES");
            }
        }

        private void GetAllRoutes()
        {
            rbo = new RouteBO();
            dtgw_all_routes.DataSource = rbo.GetAllRoutes();
            dtgw_all_routes.DataMember = "routes";
        }


        private void button7_Click(object sender, EventArgs e)
        {

            if (!VerifyExistItem(txt_prod_ord.Text))
            {
                if (!((txt_client_name.Text.Trim().Equals("")) && (txt_prod_ord.Text.Trim().Equals("")) && (txt_quantity_ord.Text.Trim().Equals(""))))
                {
                    Item i = new Item();
                    i.Id_Client = Int32.Parse(lblIdClient.Text);
                    i.Num_Order = Int32.Parse(lblIdOrder.Text);
                    i.Id_Product = lblIdProduct.Text;
                    i.Quantity = Double.Parse(txt_quantity_ord.Text);
                    i.Notes = rch_notes_ord.Text.Trim().ToUpper();
                    i.Client = txt_client_ord.Text.Trim().ToUpper();
                    i.Client_Type = Int32.Parse(lblClientType.Text);
                    i.Product = txt_prod_ord.Text.Trim().ToUpper();
                    i.Product_Code = txt_code_ord.Text.Trim().ToUpper();

                    if (txt_order_oem.Text.Trim().Equals(""))
                    {
                        i.Oem = 0;
                    }
                    else
                    {
                        i.Oem = Int32.Parse(txt_order_oem.Text.Trim());
                    }

                    DataRow dr = dtadd.NewRow();
                    dr["N° ORDEN"] = i.Num_Order;
                    dr["CÓDIGO"] = txt_code_ord.Text.Trim().ToUpper();
                    dr["PRODUCTO"] = i.Product.Trim().ToUpper();
                    dr["CANTIDAD"] = i.Quantity;
                    dr["NOTAS"] = i.Notes.Trim().ToUpper();
                    dtadd.Rows.Add(dr);
                    dtgw_items_list.DataSource = dtadd;
                    ordersList.AddLast(i);
                }
                else
                {
                    MessageBox.Show("DEBE LLENAR LOS ESPACIOS REQUERIDOS");
                }
            }
            else
            {
                MessageBox.Show("YA EXISTE UN ITEM CON EL PRODUCTO " + txt_prod_ord.Text);
            }
        }

        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            int row = dtgw_items_list.CurrentCell.RowIndex;

            DataGridViewRow selectedRow = dtgw_items_list.Rows[row];
            if (DeleteItem(Convert.ToString(selectedRow.Cells["PRODUCTO"].Value)))
            {
                dtgw_items_list.Rows.RemoveAt(row);
                MessageBox.Show("ITEM REMOVIDO EXITOSAMENTE");
            }

        }

        private bool VerifyExistItem(string product)
        {
            if (!(ordersList.Count == 0))
            {
                foreach (Item o in ordersList)
                {
                    if (o.Product.Equals(product))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DeleteItem(string product)
        {
            foreach (Item o in ordersList)
            {
                if (o.Product.Equals(product))
                {
                    ordersList.Remove(o);
                    return true;
                }
            }
            return false;
        }

        private void txt_prod_code_Leave(object sender, EventArgs e)
        {
            if (VerifyCode(txt_prod_code.Text.Trim().ToUpper()))
            {
                txt_prod_code.Text = "";
                MessageBox.Show("CÓDIGO EXISTENTE");
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            //Traer aquellos pedidos con fecha de hoy pero sin repetir numeros de orden
            //string date = DateTime.Now.ToShortDateString();
            string date = "14/2/2017";  //*****************************************************************************CHANGE
            List<Item> orders = obo.GetTodayOrders(date);
            //List<Order> ordersTemp = orders;

            foreach (Item o in orders)
            {
                foreach (Item o2 in orders)
                {
                    if ((o.Num_Order == o2.Num_Order) && (o.Id != o2.Id))
                    {
                        MessageBox.Show("1-> " + o.Id + "  " + o.Num_Order + " 2-> " + o2.Id + "  " + o2.Num_Order);
                    }
                }
                //MessageBox.Show(o.Client);
            }
        }

        private void ShowOrderDetails(DataGridView dtgw)
        {
            dtgw_items.Columns.Clear();
            CreateDtItemCol();

            int row = dtgw.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dtgw.Rows[row];
            int num_order = Int32.Parse(Convert.ToString(selectedRow.Cells["num_order"].Value));
            DataSet ds = obo.GetItemsByOrder(num_order);
            DataTable dt = ds.Tables["items"];

            foreach (DataRow dr in dt.Rows)
            {
                DataRow dtr = dtItem.NewRow();
                dtr["N° ORDEN"] = dr["num_order"].ToString();
                dtr["CÓDIGO"] = dr["product_code"].ToString();
                dtr["PRODUCTO"] = dr["product"].ToString();
                dtr["KG"] = dr["quantity"].ToString();
                dtItem.Rows.Add(dtr);
                dtgw_items.DataSource = dtItem;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            tabControl4.TabPages.Insert(2, tabPage21);
        }

        private void dtgw_orders_all_Click(object sender, EventArgs e)
        {
            try
            {
                ShowOrderDetails(dtgw_orders_all);
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO HA SELECCIONADO ORDEN");
            }
        }

        private void dtgw_orders_sch_Click(object sender, EventArgs e)
        {
            try
            {
                ShowOrderDetails(dtgw_orders_sch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO HA SELECCIONADO ORDEN");
            }
        }

        private void dtgw_orders_supers_Click(object sender, EventArgs e)
        {
            try
            {
                ShowOrderDetails(dtgw_orders_supers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO HA SELECCIONADO ORDEN");
            }
        }

        private void dtgw_orders_sev_Click(object sender, EventArgs e)
        {
            try
            {
                ShowOrderDetails(dtgw_orders_sev);
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO HA SELECCIONADO ORDEN");
            }
        }

        //trae los recordatorios de hoy de despacho
        private void GetTodayRemindersDispatch()
        {
            try
            {
                string date = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
                ordersReminder = obo.GetTodayRemOrders(date, 0);    //las ordenes de hoy
                if (ordersReminder.Count != 0)
                {
                    itemsReminder = obo.GetTodayRemItems(date);        //los items con la fecha de hoy
                    int order = ordersReminder.ElementAt(reminderDispatch);
                    string notes = "";
                    VerifyOrdersQuant();

                    for (int i = 0; i < ordersReminder.Count; i++)
                    {
                        foreach (Item it in itemsReminder)
                        {
                            if (order == it.Num_Order)
                            {
                                lblRemDeliv.Text = it.Delivery;
                                lblRemNumOrder.Text = it.Num_Order.ToString();
                                lblRemClient.Text = it.Client;
                                notes += it.Notes + "\n";
                            }
                        }
                        dtgw_RemItems.Columns.Clear();
                        CreateDtRemItemCol();

                        DataSet ds = obo.GetItemsByOrder(order);
                        DataTable dt = ds.Tables["items"];

                        foreach (DataRow dr in dt.Rows)
                        {
                            DataRow dtr = dtRemItem.NewRow();
                            dtr["CÓDIGO"] = dr["product_code"].ToString();
                            dtr["PRODUCTO"] = dr["product"].ToString();
                            dtr["KG"] = dr["quantity"].ToString();
                            dtRemItem.Rows.Add(dtr);
                            dtgw_RemItems.DataSource = dtRemItem;
                        }
                        lblRemNotes.Text = notes;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //trae las entregas de hoy de despacho
        private void GetTodayDeliveriesDispatch()
        {
            try
            {
                string date = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
                ordersDeliveries = obo.GetTodayDeliveries(date, 0);
                if (ordersDeliveries.Count != 0)
                {
                    itemsDeliveries = obo.GetTodayDeliveryItems(date);
                    int order = ordersDeliveries.ElementAt(deliveryDispatch);
                    string notes = "";
                    VerifyOrdersQuant();

                    for (int i = 0; i < ordersDeliveries.Count; i++)
                    {
                        foreach (Item it in itemsDeliveries)
                        {
                            if (order == it.Num_Order)
                            {
                                lblDelivClient.Text = it.Client;
                                lblDelivNumOrder.Text = it.Num_Order.ToString();
                                notes += it.Notes + "\n";
                            }
                        }
                        dtgw_Deliv.Columns.Clear();
                        CreateDtDelivItemCol();

                        DataSet ds = obo.GetItemsByOrder(order);
                        DataTable dt = ds.Tables["items"];

                        foreach (DataRow dr in dt.Rows)
                        {
                            DataRow dtd = dtDelivItem.NewRow();
                            dtd["CÓDIGO"] = dr["product_code"].ToString();
                            dtd["PRODUCTO"] = dr["product"].ToString();
                            dtd["KG"] = dr["quantity"].ToString();
                            dtDelivItem.Rows.Add(dtd);
                            dtgw_Deliv.DataSource = dtDelivItem;
                        }
                        lblDelivNotes.Text = notes;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Trae los recordardatorios de procesos
        private void GetTodayRemindersProcesses()
        {
            try
            {
                string date = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
                ordersReminderPro = obo.GetTodayRemOrders(date, 1);
                if (ordersReminderPro.Count != 0)
                {
                    itemsReminderPro = obo.GetTodayRemItems(date);
                    int order = ordersReminderPro.ElementAt(reminderProcesses);
                    string notes = "";
                    VerifyOrdersQuantPro();

                    for (int i = 0; i < ordersReminder.Count; i++)
                    {
                        foreach (Item it in itemsReminderPro)
                        {
                            if (order == it.Num_Order)
                            {
                                lblRemProDeliv.Text = it.Delivery;
                                lblRemProOrder.Text = it.Num_Order.ToString();
                                lblRemProClient.Text = it.Client;
                                notes += it.Notes + "\n";
                            }
                        }
                        dtgw_RemProItems.Columns.Clear();
                        CreateDtRemItemProCol();

                        DataSet ds = obo.GetItemsByOrder(order);
                        DataTable dt = ds.Tables["items"];

                        foreach (DataRow dr in dt.Rows)
                        {
                            DataRow dtr = dtRemItemPro.NewRow();
                            dtr["CÓDIGO"] = dr["product_code"].ToString();
                            dtr["PRODUCTO"] = dr["product"].ToString();
                            dtr["KG"] = dr["quantity"].ToString();
                            dtRemItemPro.Rows.Add(dtr);
                            dtgw_RemProItems.DataSource = dtRemItemPro;
                        }
                        lblRemProNotes.Text = notes;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //Trae las entregas de hoy de procesos
        private void GetTodayDeliveriesProcesses()
        {
            try
            {
                string date = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
                ordersDeliveriesPro = obo.GetTodayDeliveries(date, 1);
                if (ordersDeliveriesPro.Count != 0)
                {
                    itemsDeliveriesPro = obo.GetTodayDeliveryItems(date);
                    int order = ordersDeliveriesPro.ElementAt(deliveryProcesses);
                    string notes = "";
                    VerifyOrdersQuantPro();

                    for (int i = 0; i < ordersDeliveriesPro.Count; i++)
                    {
                        foreach (Item it in itemsDeliveriesPro)
                        {
                            if (order == it.Num_Order)
                            {
                                lblDelivProClient.Text = it.Client;
                                lblDelivProOrder.Text = it.Num_Order.ToString();
                                notes += it.Notes + "\n";
                            }
                        }
                        dtgw_DelivProItems.Columns.Clear();
                        CreateDtDelivItemCol();

                        DataSet ds = obo.GetItemsByOrder(order);
                        DataTable dt = ds.Tables["items"];

                        foreach (DataRow dr in dt.Rows)
                        {
                            DataRow dtd = dtDelivItem.NewRow();
                            dtd["CÓDIGO"] = dr["product_code"].ToString();
                            dtd["PRODUCTO"] = dr["product"].ToString();
                            dtd["KG"] = dr["quantity"].ToString();
                            dtDelivItem.Rows.Add(dtd);
                            dtgw_DelivProItems.DataSource = dtDelivItem;
                        }
                        lblDelivProNotes.Text = notes;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dtgw_RemItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            btnRemNext.Enabled = true;
            reminderDispatch--;
            if (reminderDispatch == 0)
            {
                btnRemBack.Enabled = false;
                GetTodayRemindersDispatch();
            }
            else
            {
                GetTodayRemindersDispatch();
            }
        }

        private void pnlDelivery_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            reminderDispatch++;
            btnRemBack.Enabled = true;
            if (reminderDispatch == ordersReminder.Count - 1)
            {
                btnRemNext.Enabled = false;
                GetTodayRemindersDispatch();
            }
            else
            {
                GetTodayRemindersDispatch();
            }
        }


        private void btnReminderDeliv_Click(object sender, EventArgs e)
        {
            Checks(Convert.ToInt32(lblRemNumOrder));   
        }

        private void Checks(int num_order)
        {
            DialogResult result = MessageBox.Show("¿SEGURO DE REALIZAR ENTREGA?", "Important Question", MessageBoxButtons.YesNo);
            if (result.ToString().Equals("Yes"))
            {
                if (obo.CheckOrder(num_order))
                {
                    MessageBox.Show("ENTREGA EXITOSA");
                    GetTodayRemindersDispatch();
                    GetTodayRemindersProcesses();
                    GetTodayDeliveriesDispatch();
                    GetTodayDeliveriesProcesses();
                }else
                {
                    MessageBox.Show("ERROR EN ENTREGA");
                }
            }
        }

        private void VerifyOrdersQuant()
        {
            if (ordersReminder != null)
            {
                if (ordersReminder.Count == 1)
                {
                    btnRemNext.Enabled = false;
                    btnReminderDeliv.Enabled = true;
                }
                else if (ordersReminder.Count < 1)
                {
                    btnRemNext.Enabled = false;
                    btnReminderDeliv.Enabled = false;
                }
            }

            if (ordersDeliveries != null)
            {
                if (ordersDeliveries.Count == 1)
                {
                    btnDelivNext.Enabled = false;
                    btnDeliv.Enabled = true;
                }
                else if (ordersDeliveries.Count < 1)
                {
                    btnDelivNext.Enabled = false;
                    btnDeliv.Enabled = false;
                }
            }
        }

        private void VerifyOrdersQuantPro()
        {
            if (ordersReminderPro != null)
            {
                if (ordersReminderPro.Count == 1)
                {
                    btnRemProNext.Enabled = false;
                    btnDelivPro.Enabled = true;
                }
                else if (ordersReminderPro.Count < 1)
                {
                    btnRemProNext.Enabled = false;
                    btnDelivPro.Enabled = false;
                }
            }

            if (ordersDeliveriesPro != null)
            {
                if (ordersDeliveriesPro.Count == 1)
                {
                    btnDelivProNext.Enabled = false;
                    btnDelivPro.Enabled = true;
                }
                else if (ordersDeliveriesPro.Count < 1)
                {
                    btnDelivProNext.Enabled = false;
                    btnDelivPro.Enabled = false;
                }
            }
        }

        private void btnDelivBack_Click(object sender, EventArgs e)
        {
            btnDelivNext.Enabled = true;
            deliveryDispatch--;
            if (deliveryDispatch == 0)
            {
                btnDelivBack.Enabled = false;
                GetTodayDeliveriesDispatch();
            }
            else
            {
                GetTodayDeliveriesDispatch();
            }
        }

        private void btnDelivNext_Click(object sender, EventArgs e)
        {
            deliveryDispatch++;
            btnDelivBack.Enabled = true;
            if (deliveryDispatch == ordersDeliveries.Count - 1)
            {
                btnDelivNext.Enabled = false;
                GetTodayDeliveriesDispatch();
            }
            else
            {
                GetTodayDeliveriesDispatch();
            }
        }

        private void btnRemProBack_Click(object sender, EventArgs e)
        {
            btnRemProNext.Enabled = true;
            reminderProcesses--;
            if (reminderProcesses == 0)
            {
                btnRemProBack.Enabled = false;
                GetTodayRemindersProcesses();
            }
            else
            {
                GetTodayRemindersProcesses();
            }
        }

        private void btnRemProNext_Click(object sender, EventArgs e)
        {
            reminderProcesses++;
            btnRemProBack.Enabled = true;
            if (reminderProcesses == ordersReminder.Count - 1)
            {
                //btnRemProNext.Enabled = false;
                GetTodayRemindersProcesses();
            }
            else
            {
                GetTodayRemindersProcesses();
            }
        }

        private void btnDelivProBack_Click(object sender, EventArgs e)
        {
            btnDelivProNext.Enabled = true;
            deliveryProcesses--;
            if (deliveryProcesses == 0)
            {
                btnDelivProBack.Enabled = false;
                GetTodayDeliveriesProcesses();
            }
            else
            {
                GetTodayDeliveriesProcesses();
            }
        }

        private void btnDelivProNext_Click(object sender, EventArgs e)
        {
            deliveryProcesses++;
            btnDelivProBack.Enabled = true;
            if (deliveryProcesses == ordersDeliveriesPro.Count - 1)
            {
                btnDelivProNext.Enabled = false;
                GetTodayDeliveriesProcesses();
            }
            else
            {
                GetTodayDeliveriesProcesses();
            }
        }

        private void btnRemProDeliv_Click(object sender, EventArgs e)
        {
            Checks(Convert.ToInt32(lblRemProClient));
        }

        private void btnDeliv_Click(object sender, EventArgs e)
        {
            Checks(Convert.ToInt32(lblDelivClient));
        }

        private void btnDelivPro_Click(object sender, EventArgs e)
        {
            Checks(Convert.ToInt32(lblDelivProClient));
        }
    }
}
