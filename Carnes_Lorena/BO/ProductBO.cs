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
    public class ProductBO
    {
        private ProductDAO pdao;

        public ProductBO()
        {
            pdao = new ProductDAO();
        }

        public DataSet GetAllProducts()
        {
            return pdao.GetAllProducts();
        }

        public DataTable GetByName(string name)
        {
            return pdao.GetByName(name);
        }

        public DataTable GetByCode(string code)
        {
            return pdao.GetByCode(code);
        }

        public bool RegisterProduct(Product p)
        {
            return pdao.RegisterProduct(p);
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
