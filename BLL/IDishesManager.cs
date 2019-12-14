using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishesManager
    {
        List<Dishes> GetDishes();

        List<Dishes> GetDishesOfRestaurant(int id);

        int GetDishePrice(int id);

        Dishes GetDishe(int id);
    }
}
