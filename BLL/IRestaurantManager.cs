using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IRestaurantManager
    {
        IRestaurantDB RestaurantDB { get; }

        Restaurant AddRestaurant(Restaurant restaurant);

        List<Restaurant> GetRestaurants();

        Restaurant UpdateRestaurant(Restaurant restaurant);

        Restaurant DeleteRestaurant(int id);
    }
}
