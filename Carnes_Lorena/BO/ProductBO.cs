using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAO;
using System.Data;

namespace BO
{
    public class ProductBO
    {
        private ProductDAO pdao;

        public ProductBO()
        {
            pdao = new ProductDAO();
        }

        public bool RegisterProduct(Product p)
        {
            return pdao.RegisterProduct(p);
        }

        public DataSet GetAllProducts()
        {
            return pdao.GetAllProducts();
        }

        public DataTable GetByCode(string code)
        {
            return pdao.GetByCode(code);
        }

        public DataTable GetByName(string name)
        {
            return pdao.GetByName(name);
        }

        public DataTable Get_Products_Code()
        {
            return pdao.Get_Products_Code();
        }

        public DataTable Get_Products_Name()
        {
            return pdao.Get_Products_Name();
        }

        public string Get_Product_Name(string code)
        {
            return pdao.Get_Product_Name(code);
        }

        public string Get_Code_By_Name(string name)
        {
            return pdao.Get_Code_By_Name(name);
        }
    }
}
