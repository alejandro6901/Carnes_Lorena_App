﻿using Entities;
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

        public Orders ShowOrder(int id)
        {
            return odao.ShowOrder(id);
        }

    }
}