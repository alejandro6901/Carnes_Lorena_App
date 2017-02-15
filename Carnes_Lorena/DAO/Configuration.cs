using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Configuration
    {
        /// <summary>
        /// Metodo que establece la conexion con la base datos 
        /// </summary>
        private static string cadenaConexion = String.Format(
            "Server={0};Port={1};User Id={2};"
          + "Password={3};Database={4};", "localhost", 5432,
            "postgres", "pico", "lorena_pedidos");

        public static string CadenaConexion
        {
            get { return cadenaConexion; }

        }

    }
}
