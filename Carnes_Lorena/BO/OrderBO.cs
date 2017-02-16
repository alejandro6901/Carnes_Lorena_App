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
    public class OrderBO
    {

        private OrderDAO odao;

        public OrderBO()
        {
            odao = new OrderDAO();
        }

        public DataSet GetAllOrders()
        {
            return odao.GetAllOrders();
        }

        public DataSet GetSchoolOrders()
        {
            return odao.GetSchoolOrders();
        }

        public DataSet GetSupermarketOrders()
        {
            return odao.GetSupermarketOrders();
        }

        public DataSet GetSeveralOrders()
        {
            return odao.GetSeveralOrders();
        }

        public int GetLastId()
        {
            return odao.GetLastId();
        }

        public bool RegisterItems(LinkedList<Item> items)
        {
            return odao.RegisterAll(items);
        }

        public bool RegisterOrder(Order o)
        {
            return odao.RegisterOrder(o);
        }

        public List<Item> GetTodayOrders(string date)
        {
            return odao.GetTodayOrders(date);
        }

        public DataSet GetItemsByOrder(int num_order)
        {
            return odao.GetItemsByOrder(num_order);
        }

        public LinkedList<int> GetTodayReminders(string date)
        {
            return odao.GetTodayReminders(date);
        }

        public LinkedList<Item> GetTodayRemItems(string date)
        {
            return odao.GetTodayRemItems(date);
        }
    }
}
