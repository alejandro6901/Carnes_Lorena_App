using System;
using Npgsql;
using Entities;
using System.Data;

namespace DAO
{
    public class CustomerDAO
    {
        public DataSet GetAllCustomers()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daCustomers = new NpgsqlDataAdapter("SELECT * FROM public.customers;", con);
                    DataSet ds = new DataSet();
                    daCustomers.Fill(ds, "customers");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int GetByName(string name)
        {
            int result = 0;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT type FROM public.customers WHERE named = :n";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("n", name);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = reader.GetInt16(0);
                        con.Close();
                        return result;
                    }
                    con.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
            
    }
}
