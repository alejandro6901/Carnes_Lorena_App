using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entities;

namespace BO
{
    public class SchoolBO
    {
        private SchoolDAO sdao;

        public SchoolBO()
        {
            sdao = new SchoolDAO();
        }

        public DataTable GetByName(string name)
        {
            return sdao.GetByName(name);
        }

        public bool RegisterSchool(School s)
        {
            return sdao.RegisterSchool(s);
        }

        public DataSet GetAllSchools()
        {
            return sdao.GetAllSchools();
        }
    }
}
