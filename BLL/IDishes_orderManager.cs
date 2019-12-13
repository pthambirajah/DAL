using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishes_orderManager
    {
        IDishes_orderDB Dishes_orderDB { get; }

        Dishes_order AddDishes_order(Dishes_order dishes_order);

        List<deliveryItem> GetDishes_orderByStaff(int id);

        List<deliveryItem> GetDishes_orderByCustomer(int id);
        void UpdateOrderStatus(int id);
        void UpdateOrderStatusToCancel(int id);
    }
}
