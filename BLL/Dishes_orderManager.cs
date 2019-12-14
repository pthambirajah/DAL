using System;
using DAL;
using DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class Dishes_orderManager
    {
        private IDishes_orderDB Dishes_orderDb { get; }

        public Dishes_orderManager(IConfiguration configuration)
        {
            Dishes_orderDb = new Dishes_orderDB(configuration);
        }

        public List<deliveryItem> GetDishes_orderByCustomer(int id)
        {
            return Dishes_orderDb.GetDishes_orderByCustomer(id);
        }
       

        public void AddDishes_order(int idDishe, int idLastOrder, int quantity)
        {
            Dishes_orderDb.AddDishes_order(idDishe, idLastOrder, quantity);
        }

        public List<deliveryItem> GetDishes_orderByStaff(int id)
        {
            return Dishes_orderDb.GetDishes_orderByStaff(id);        
        }

        public void UpdateOrderStatus(int id)
        {
            Dishes_orderDb.UpdateOrderStatus(id);
        }

        public void UpdateOrderStatusToCancel(int id)
        {
            Dishes_orderDb.UpdateOrderStatusToCancel(id);
        }
    }
}
