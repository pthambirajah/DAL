using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IDishesDB
    {
        IConfiguration Configuration { get; }

        Dishes AddDishes(Dishes dishes);
        int DeleteDishes(int id);
        Dishes GetDishes(int id);
        int UpdateDishes(Dishes dishes);
    }
}
