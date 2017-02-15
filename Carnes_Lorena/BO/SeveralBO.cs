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
    public class SeveralBO
    {
        private SeveralDAO svdao;

        public SeveralBO()
        {
            svdao = new SeveralDAO();
        }

        public DataTable GetByName(string name)
        {
            return svdao.GetByName(name);
        }

        public bool RegisterSeveral(Several sv)
        {
            return svdao.RegisterSeveral(sv);
        }

        public DataSet GetAllSeverals()
        {
            return svdao.GetAllSeverals();
        }
    }
}
