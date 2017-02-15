using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SupermarketBO
    {
        private SupermarketDAO spdao;

        public SupermarketBO()
        {
            spdao = new SupermarketDAO();
        }

        public DataTable GetByName(string name)
        {
            return spdao.GetByName(name);
        }

        public bool RegisterSupermarket(Supermarket sp)
        {
            return spdao.RegisterSupermarket(sp);
        }

        public DataSet GetAllSupermarkets()
        {
            return spdao.GetAllSupermarkets();
        }
    }
}
