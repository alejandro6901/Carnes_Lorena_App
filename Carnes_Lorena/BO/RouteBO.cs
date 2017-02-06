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
    public class RouteBO
    {
        RouteDAO rdao;

        public RouteBO()
        {
            rdao = new RouteDAO();
        }

        public List<Routes> Load_Routes()
        {
            return rdao.Load_Routes();
        }
    }
}
