using System;
using DAL;
using DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantManager
    {

        public IRestaurantDB RestaurantDb { get; }


        public RestaurantManager(IConfiguration configuration)
        {
            RestaurantDb = new RestaurantDB(configuration);
        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDb.GetRestaurants();
        }

        public List<Restaurant> GetRestaurantsOfCity(int id)
        {
            return RestaurantDb.GetRestaurantsOfCity(id);
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDb.GetRestaurant(id);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDb.AddRestaurant(restaurant);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDb.UpdateRestaurant(restaurant);

        }

        public int DeleteRestaurant(int id)
        {
            return RestaurantDb.DeleteRestaurant(id);
        }

    }
}
