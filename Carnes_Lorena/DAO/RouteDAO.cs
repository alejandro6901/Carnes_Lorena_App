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
    public class RouteDAO
    {
        public List<Route> Load_Routes()
        {
            List<Route> routes = new List<Route>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
            {
                con.Open();
                string sql = @"SELECT * FROM routes";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Route r = new Route()
                    {
                        Id = reader.GetInt32(0),
                        Named = reader.GetString(1)
                    };
                    routes.Add(r);
                }
            }
            return routes;
        }

        public DataSet GetAllRoutes()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daOrders = new NpgsqlDataAdapter("SELECT * FROM public.routes;", con);
                    DataSet ds = new DataSet();
                    daOrders.Fill(ds, "routes");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool RegisterRoute(Route r)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuration.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"INSERT INTO public.routes(
                                      named)
                                VALUES(:n) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("n", r.Named);

                    r.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Close();
                    return r.Id > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
