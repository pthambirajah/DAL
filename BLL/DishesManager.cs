using System;
using DAL;
using DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DishesManager
    {

        public IDishesDB DishesDb { get; }


        public DishesManager(IConfiguration configuration)
        {
            DishesDb = new DishesDB(configuration);
        }

        public List<Dishes> GetDishes()
        {
            return DishesDb.GetDishes();
        }

        public List<Dishes> GetDishesOfRestaurant(int id)
        {
            return DishesDb.GetDishesOfRestaurant(id);
        }

        public Dishes GetDishe(int id)
        {
            return DishesDb.GetDishe(id);
        }

        public Dishes AddDishes(Dishes dishes)
        {
            return DishesDb.AddDishes(dishes);
        }

        public int UpdateDishes(Dishes dishes)
        {
            return DishesDb.UpdateDishes(dishes);

        }

        public int DeleteDishes(int id)
        {
            return DishesDb.DeleteDishes(id);
        }

    }
}
