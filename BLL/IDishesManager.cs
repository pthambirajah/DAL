using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishesManager
    {
        IDishesDB DishesDB { get; }

        Dishes AddDishes(Dishes dishes);

        Dishes UpdateDishes(Dishes dishes);

        Dishes DeleteDishes(int id);
    }
}
