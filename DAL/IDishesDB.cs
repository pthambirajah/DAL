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
        Dishes GetDishe(int id);
        List<Dishes> GetDishes();
        int UpdateDishes(Dishes dishes);
    }
}
