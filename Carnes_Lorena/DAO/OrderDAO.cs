using Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class OrderDAO
    {
        //Encargado de traer todos los pedidos
        public DataSet GetAllOrders()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daOrders = new NpgsqlDataAdapter("SELECT * FROM public.orders;", con);
                    DataSet ds = new DataSet();
                    daOrders.Fill(ds, "orders");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Encargado de traer todos los pedidos por escuelas
        public DataSet GetSchoolOrders()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daOrders = new NpgsqlDataAdapter("SELECT * FROM public.orders WHERE client_type = 1;", con);
                    DataSet ds = new DataSet();
                    daOrders.Fill(ds, "orders");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Encargado de traer todos los pedidos por supers
        public DataSet GetSupermarketOrders()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daOrders = new NpgsqlDataAdapter("SELECT * FROM public.orders"
                         + " WHERE client_type = 2;", con);
                    DataSet ds = new DataSet();
                    daOrders.Fill(ds, "orders");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Encargado de traer todos los pedidos por varios
        public DataSet GetSeveralOrders()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daOrders = new NpgsqlDataAdapter("SELECT * FROM public.orders"
                         + " WHERE client_type = 3;", con);
                    DataSet ds = new DataSet();
                    daOrders.Fill(ds, "orders");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Obtener el último id de tabla órdenes
        public int GetLastId()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    string sql = "select num_order from public.orders order by id desc limit 1";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Registrar item
        public bool RegisterItem(Item i)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"INSERT INTO public.items(
                                      id_client, id_product, quantity, notes, client, product, product_code, state, created, 
                                      delivery, reminder, department, client_type, num_order, oem)
                                VALUES(:ic, :ip, :q, :n, :cl, :pr, :prc, :st, :cr, :dl, :rm, :dp, :ct, :no, :oe) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("ic", i.Id_Client);
                    cmd.Parameters.AddWithValue("ip", i.Id_Product);
                    cmd.Parameters.AddWithValue("q", i.Quantity);
                    cmd.Parameters.AddWithValue("n", i.Notes);
                    cmd.Parameters.AddWithValue("cl", i.Client);
                    cmd.Parameters.AddWithValue("ct", i.Client_Type);
                    cmd.Parameters.AddWithValue("pr", i.Product);
                    cmd.Parameters.AddWithValue("prc", i.Product_Code);
                    cmd.Parameters.AddWithValue("st", i.State);
                    cmd.Parameters.AddWithValue("cr", i.Created);
                    cmd.Parameters.AddWithValue("dl", i.Delivery);
                    cmd.Parameters.AddWithValue("rm", i.Reminder);
                    cmd.Parameters.AddWithValue("dp", i.Department);
                    cmd.Parameters.AddWithValue("no", i.Num_Order);
                    cmd.Parameters.AddWithValue("oe", i.Oem);

                    i.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Close();
                    return i.Id > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //método que reciba linkedlist, tome uno por uno llamando al método de registrar item
        public bool RegisterAll(LinkedList<Item> items)
        {
            foreach (Item i in items)
            {
                if (!(RegisterItem(i)))
                {
                    return false;
                }
            }
            return true;
        }

        public List<Item> GetTodayOrders(string date)
        {
            try
            {
                List<Item> orders = new List<Item>();
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    string sql = "select id, num_order, client from public.orders where created = '" + date + "';";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        orders.Add(new Item() { Id = reader.GetInt32(0), Num_Order = reader.GetInt32(1), Client = reader.GetString(2) });
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RegisterOrder(Order o)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"INSERT INTO public.orders(
                                      num_order, client, client_type, oem, state, 
                                      department, created, delivery, reminder)
                                VALUES(:no, :cl, :ct, :oe, :st, :dp, :cr, :dl, :rm) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("no", o.Num_Order);
                    cmd.Parameters.AddWithValue("cl", o.Client);
                    cmd.Parameters.AddWithValue("ct", o.Client_Type);
                    cmd.Parameters.AddWithValue("oe", o.Oem);
                    cmd.Parameters.AddWithValue("st", o.State);
                    cmd.Parameters.AddWithValue("dp", o.Department);
                    cmd.Parameters.AddWithValue("cr", o.Created);
                    cmd.Parameters.AddWithValue("dl", o.Delivery);
                    cmd.Parameters.AddWithValue("rm", o.Reminder);

                    o.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Close();
                    return o.Id > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataSet GetItemsByOrder(int num_order)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daOrders = new NpgsqlDataAdapter("SELECT * FROM public.items"
                         + " WHERE num_order = '" + num_order + "';", con);
                    DataSet ds = new DataSet();
                    daOrders.Fill(ds, "items");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<int> GetTodayRemOrders(string date, int department)
        {
            try
            {
                List<int> orders = new List<int>();
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    string sql = "select num_order from orders where reminder = '" + date + "' and state = 0 and department = " + department;
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        orders.Add(reader.GetInt32(0));
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LinkedList<Item> GetTodayRemItems(string date)
        {
            try
            {
                LinkedList<Item> items = new LinkedList<Item>();
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    string sql = @"select num_order, client, quantity, notes, oem, state, department, delivery, 
                                    product, product_code from items where reminder = '" + date + "' and state = 0;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        items.AddLast(new Item
                        {
                            Num_Order = reader.GetInt32(0),
                            Client = reader.GetString(1),
                            Quantity = double.Parse(reader.GetString(2)),
                            Notes = reader.GetString(3),
                            Oem = reader.GetInt32(4),
                            State = reader.GetInt16(5),
                            Department = reader.GetInt16(6),
                            Delivery = reader.GetString(7),
                            Product = reader.GetString(8),
                            Product_Code = reader.GetString(9)
                        });
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<int> GetTodayDeliveries(string date, int department)
        {
            try
            {
                List<int> orders = new List<int>();
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    string sql = "select num_order from orders where delivery = '" + date + "'and state = 0 and department = " + department;
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        orders.Add(reader.GetInt32(0));
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LinkedList<Item> GetTodayDeliveryItems(string date)
        {
            try
            {
                LinkedList<Item> items = new LinkedList<Item>();
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    string sql = @"select num_order, client, quantity, notes, oem, state, department, delivery, 
                                    product, product_code from items where delivery = '" + date + "' and state = 0;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        items.AddLast(new Item
                        {
                            Num_Order = reader.GetInt32(0),
                            Client = reader.GetString(1),
                            Quantity = double.Parse(reader.GetString(2)),
                            Notes = reader.GetString(3),
                            Oem = reader.GetInt32(4),
                            State = reader.GetInt16(5),
                            Department = reader.GetInt16(6),
                            Delivery = reader.GetString(7),
                            Product = reader.GetString(8),
                            Product_Code = reader.GetString(9)
                        });
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckOrder(int num_order)
        {
            NpgsqlTransaction trans = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    trans = con.BeginTransaction();

                    string sql = @"UPDATE orders
                      SET 
                      state = 1
                      WHERE num_order = " + num_order + ";";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.ExecuteScalar();
                    trans.Commit();
                    if (CheckItems(num_order))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool CheckItems(int num_order)
        {
            NpgsqlTransaction trans = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    trans = con.BeginTransaction();

                    string sql = @"UPDATE items
                      SET 
                      state = 1
                      WHERE num_order = " + num_order + ";";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    trans.Commit();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
