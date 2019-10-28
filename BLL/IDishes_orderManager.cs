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

        Dishes_order UpdateDishes_order(Dishes_order dishes_order);

        Dishes_order DeleteDishes_order(int id);
    }
}
