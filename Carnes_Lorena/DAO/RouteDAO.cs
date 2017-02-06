using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using Entities;

namespace DAO
{
    public class RouteDAO
    {
        public List<Routes> Load_Routes()
        {
            List<Routes> routes = new List<Routes>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                string sql = @"SELECT * FROM routes";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Routes r = new Routes()
                    {
                        Id = reader.GetInt32(0),
                        Named = reader.GetString(1)
                    };
                    routes.Add(r);
                }
            }
            return routes;
        }
    }
}
