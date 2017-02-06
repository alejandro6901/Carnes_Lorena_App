using DAO;
using Entities;
using System.Data;

namespace BO
{
    public class SchoolsBO
    {
        private SchoolDAO sdao;

        public SchoolsBO()
        {
            sdao = new SchoolDAO();
        }

        public bool RegisterSchool(Schools s)
        {
            return sdao.RegisterSchool(s);
        }

        public DataSet GetAllSchools()
        {
            return sdao.GetAllSchools();
        }

        public DataTable GetByName(string name)
        {
            return sdao.GetByName(name);
        }
    }
}
