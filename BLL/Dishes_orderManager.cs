﻿using System;
using DAL;
using DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class Dishes_orderManager
    {

        public IDishes_orderDB Dishes_orderDb { get; }


        public Dishes_orderManager(IConfiguration configuration)
        {
            Dishes_orderDb = new Dishes_orderDB(configuration);
        }


        public Dishes_order GetDishes_order(int id)
        {
            return Dishes_orderDb.GetDishes_order(id);
        }

        public Dishes_order AddDishes_order(Dishes_order dishes_order)
        {
            return Dishes_orderDb.AddDishes_order(dishes_order);
        }

        public int UpdateDishes_order(Dishes_order dishes_order)
        {
            return Dishes_orderDb.UpdateDishes_order(dishes_order);

        }

        public int DeleteDishes_order(int id)
        {
            return Dishes_orderDb.DeleteDishes_order(id);
        }

        public List<deliveryItem> GetDishes_orderByStaff(int id)
        {
            return Dishes_orderDb.GetDishes_orderByStaff(id);        
        }

    }
}