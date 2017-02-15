using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CustomerBO
    {
        CustomerDAO cdao;

        public CustomerBO()
        {
            cdao = new CustomerDAO();
        }

        public DataSet GetAllCustomers()
        {
            return cdao.GetAllCustomers();
        }

        public int GetByName(string name)
        {
            return cdao.GetByName(name);
        }

        public DataTable Get_Clients_Name()
        {
            return cdao.Get_Clients_Name();
        }

        public string GetIdByName(string name)
        {
            return cdao.GetIdByName(name);
        }
    }
}
