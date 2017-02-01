using System;
using Npgsql;
using Entities;
using System.Data;

namespace DAO
{
    public class SchoolDAO
    {
        public bool RegisterSchool(Schools s)
        {
            Customers c = new Customers();
            c.Named = s.Named;
            s.Id_Global = Register(c);
            if (s.Id_Global > 0)
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
                                      id_route, id_global)
                                VALUES(:n, :u, :c1, :c2, :t1, :t2, :m, :ns, :ir, :ig) returning id";

                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("n", s.Named);
                        cmd.Parameters.AddWithValue("u", s.Ubication);
                        cmd.Parameters.AddWithValue("c1", s.Manager1);
                        cmd.Parameters.AddWithValue("c2", s.Manager2);
                        cmd.Parameters.AddWithValue("t1", s.Phone1);
                        cmd.Parameters.AddWithValue("t2", s.Phone2);
                        cmd.Parameters.AddWithValue("m", s.Mail);
                        cmd.Parameters.AddWithValue("ns", s.Notes);
                        cmd.Parameters.AddWithValue("ir", s.Id_Route);
                        cmd.Parameters.AddWithValue("ig", s.Id_Global);

                        s.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        tran.Commit();
                        con.Close();
                        return s.Id > 0;
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
                                    named)
                                 VALUES (:n) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("n", c.Named);
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

        public DataSet GetAllSchools()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daSchools = new NpgsqlDataAdapter("SELECT * FROM public.schools;", con);
                    DataSet ds = new DataSet();
                    daSchools.Fill(ds, "schools");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
