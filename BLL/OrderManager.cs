using System;
using DAL;
using DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class OrderManager
    {

        public IOrderDB OrderDb { get; }


        public OrderManager(IConfiguration configuration)
        {
            OrderDb = new OrderDB(configuration);
        }


        public Order GetOrder(int id)
        {
            return OrderDb.GetOrder(id);
        }

        public int GetLastId()
        {
            return OrderDb.GetLastId();
        }

        public void AddOrder(int idCustomer, int idDelivery)
        {
            OrderDb.AddOrder(idCustomer, idDelivery);
        }

        public int UpdateOrder(Order order)
        {
            return OrderDb.UpdateOrder(order);

        }

        public int DeleteOrder(int id)
        {
            return OrderDb.DeleteOrder(id);
        }

    }
}
