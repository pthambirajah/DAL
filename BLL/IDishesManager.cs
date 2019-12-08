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
        List<Dishes> GetDishes();

        List<Dishes> GetDishesOfRestaurant(int id);

        Dishes AddDishes(Dishes dishes);

        Dishes UpdateDishes(Dishes dishes);

        Dishes DeleteDishes(int id);

        Dishes GetDishe(int id);
    }
}
