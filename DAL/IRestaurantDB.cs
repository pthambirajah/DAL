using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using DTO;

namespace DAL
{
    public interface IRestaurantDB
    {
        IConfiguration Configuration { get; }

        Staff AddRestaurant(Restaurant restaurant);
        int DeleteRestaurant(int id);
        Restaurant GetRestaurant(int id);
        int UpdateRestaurant(Restaurant restaurant);
    }
}
