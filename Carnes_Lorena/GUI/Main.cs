﻿using BO;
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
        string gb_client_name;
        DataTable dtadd;
        LinkedList<Item> ordersList;
        List<string> list_clients;
        List<string> list_product_codes;
        List<string> list_products;

        public Main()
        {
            InitializeComponent();
            gb_client_name = "";
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
            ordersList = new LinkedList<Item>();
            dtadd = new DataTable();
            dtadd.Columns.Add("N° ORDEN");
            dtadd.Columns.Add("CÓDIGO");
            dtadd.Columns.Add("PRODUCTO");
            dtadd.Columns.Add("CANTIDAD");
            dtadd.Columns.Add("NOTAS");

            RefreshAllOnStart();
            GetAllRoutes();

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
            if (!(txt_name.Text.Trim().Equals("")))
            {
                school = new School();
                school.Named = txt_name.Text.Trim().ToUpper();
                school.Ubication = txt_ubication.Text.Trim().ToUpper();
                school.Manager1 = txt_manager1.Text.Trim().ToUpper();
                school.Manager2 = txt_manager2.Text.Trim().ToUpper();
                school.Phone1 = Int32.Parse(txt_tel1.Text);
                school.Phone2 = Int32.Parse(txt_tel2.Text);
                school.Mail = txt_mail.Text.Trim();
                school.Notes = rch_client_notes.Text.Trim().ToUpper();
                school.Route = cbx_routes.SelectedItem.ToString();
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
            o.Client = txt_client_ord.Text;
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
                    MessageBox.Show("CLIENTE INCORRECTO, DIRÍJASE A LA PESTAÑA CLIENTES PARA MODIFICAR SI LO DESEA");
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
                    Item o = new Item();
                    o.Id_Client = Int32.Parse(lblIdClient.Text);
                    o.Num_Order = Int32.Parse(lblIdOrder.Text);
                    o.Id_Product = lblIdProduct.Text;
                    o.Quantity = Double.Parse(txt_quantity_ord.Text);
                    o.Notes = rch_notes_ord.Text.Trim().ToUpper();
                    o.Client = txt_client_ord.Text;
                    o.Client_Type = Int32.Parse(lblClientType.Text);
                    o.Product = txt_prod_ord.Text;

                    if (txt_order_oem.Text.Trim().Equals(""))
                    {
                        o.Oem = 0;
                    }
                    else
                    {
                        o.Oem = Int32.Parse(txt_order_oem.Text.Trim());
                    }

                    DataRow dr = dtadd.NewRow();
                    dr["N° ORDEN"] = o.Num_Order;
                    dr["CÓDIGO"] = txt_code_ord.Text;
                    dr["PRODUCTO"] = o.Product;
                    dr["CANTIDAD"] = o.Quantity;
                    dr["NOTAS"] = o.Notes;
                    dtadd.Rows.Add(dr);
                    dtgw_items_list.DataSource = dtadd;
                    ordersList.AddLast(o);
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
            string date = "14/2/2017";
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
    }
}
