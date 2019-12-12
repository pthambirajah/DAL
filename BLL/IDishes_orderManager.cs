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

        void AddDishes_order(int idDishe, int idLastOrder, int quantity);

        Dishes_order UpdateDishes_order(Dishes_order dishes_order);

        Dishes_order DeleteDishes_order(int id);

        List<deliveryItem> GetDishes_orderByStaff(int id);

    }
}
