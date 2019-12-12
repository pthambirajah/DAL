using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrderManager
    {
        IOrderDB OrderDB { get; }

        void AddOrder(int idCustomer, int idDelivery);

        Order UpdateOrder(Order order);

        Order DeleteOrder(int id);

        int GetLastId();
    }
}
