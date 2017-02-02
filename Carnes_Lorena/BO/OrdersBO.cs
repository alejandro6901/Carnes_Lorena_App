using Entities;
using DAO;
using System.Data;

namespace BO
{
    public class OrdersBO
    {
        private OrdersDAO odao;

        public OrdersBO()
        {
            odao = new OrdersDAO();
        }

        public bool RegisterOrder(Orders o)
        {
            return odao.RegisterOrder(o);
        }

        public DataSet GetAllOrders()
        {
            return odao.GetAllOrders();
        }

        public Orders ShowOrderById(int id)
        {
            return odao.ShowOrderById(id);
        }

        public Orders ShowOrderByClient(string client)
        {
            return odao.ShowOrderByClient(client);
        }

        public int UpdateOrder(Orders o)
        {
            return odao.UpdateOrder(o);
        }
    }
}
