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

        Order AddOrder(Order order);

        Order UpdateOrder(Order order);

        Order DeleteOrder(int id);

        Order UpdateOrderStatus(int id);

    }
}
