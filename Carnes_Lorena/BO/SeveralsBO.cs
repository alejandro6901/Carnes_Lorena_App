using DAO;
using Entities;
using System.Data;

namespace BO
{
    public class SeveralsBO
    {
        private SeveralsDAO svdao;

        public SeveralsBO()
        {
            svdao = new SeveralsDAO();
        }

        public bool RegisterSeveral(Severals sv)
        {
            return svdao.RegisterSeveral(sv);
        }

        public DataSet GetAllSeverals()
        {
            return svdao.GetAllSeverals();
        }
    }
}
