using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IDishes_orderDB
    {
        IConfiguration Configuration { get; }

        Dishes_order AddDishes_order(Dishes_order dishes_order);
        int DeleteDishes_order(int id);
        Dishes_order GetDishes_order(int id);
        int UpdateDishes_order(Dishes_order dishes_order);

        List<deliveryItem> GetDishes_orderByStaff(int id);

    }
}
