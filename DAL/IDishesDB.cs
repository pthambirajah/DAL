using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IDishesDB
    {
        Dishes GetDishe(int id);
        List<Dishes> GetDishes();
        List<Dishes> GetDishesOfRestaurant(int id);
        int GetDishePrice(int id);
    }
}
