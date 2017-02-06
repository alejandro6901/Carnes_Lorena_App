using System;
using Npgsql;
using Entities;
using System.Data;

namespace DAO
{
    public class SupermarketDAO
    {
        public bool RegisterSupermarket(Supermarkets sp)
        {
            Customers c = new Customers();
            c.Named = sp.Named;
            sp.Id_Global = Register(c);
            if (sp.Id_Global > 0)
            {
                NpgsqlTransaction tran = null;
                try
                {
                    using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                    {
                        con.Open();
                        tran = con.BeginTransaction();
                        string sql = @"INSERT INTO public.schools(
                                      named, ubication, contact1, contact2, tel1, tel2, mail, notes, 
                                      id_global)
                                VALUES(:n, :u, :c1, :c2, :t1, :t2, :m, :ns, :ig) returning id";

                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("n", sp.Named);
                        cmd.Parameters.AddWithValue("u", sp.Ubication);
                        cmd.Parameters.AddWithValue("c1", sp.Manager1);
                        cmd.Parameters.AddWithValue("c2", sp.Manager2);
                        cmd.Parameters.AddWithValue("t1", sp.Phone1);
                        cmd.Parameters.AddWithValue("t2", sp.Phone2);
                        cmd.Parameters.AddWithValue("m", sp.Mail);
                        cmd.Parameters.AddWithValue("ns", sp.Notes);
                        cmd.Parameters.AddWithValue("ig", sp.Id_Global);

                        sp.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        tran.Commit();
                        con.Close();
                        return sp.Id > 0;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return false;
        }

        public int Register(Customers c)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"INSERT INTO public.customers(
                                    named, type)
                                 VALUES (:n, :t) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("n", c.Named);
                    cmd.Parameters.AddWithValue("t", 2);
                    c.Id = Convert.ToInt32(cmd.ExecuteScalar());

                    tran.Commit();
                    con.Close();
                    return c.Id;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public DataSet GetAllSupermarkets()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daSupermarkets = new NpgsqlDataAdapter("SELECT * FROM public.supermarkets;", con);
                    DataSet ds = new DataSet();
                    daSupermarkets.Fill(ds, "supermarkets");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataTable GetByName(string name)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT * FROM public.supermarkets
                                    WHERE named = '" + name + "'";

                    var da = new NpgsqlDataAdapter(sql, con);
                    ds.Reset();

                    da.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    }
}
