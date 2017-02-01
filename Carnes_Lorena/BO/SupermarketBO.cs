using DAO;
using Entities;
using System.Data;

namespace BO
{
    public class SupermarketBO
    {
        private SupermarketDAO spdao;

        public SupermarketBO()
        {
            spdao = new SupermarketDAO();
        }

        public bool RegisterSupermarket(Supermarkets sp)
        {
            return spdao.RegisterSupermarket(sp);
        }

        public DataSet GetAllSupermarkets()
        {
            return spdao.GetAllSupermarkets();
        }
    }
}
