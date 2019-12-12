using System;
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

        public List<deliveryItem> GetDishes_orderByCustomer(int id)
        {
            return Dishes_orderDb.GetDishes_orderByCustomer(id);
        }
        public Dishes_order GetDishes_order(int id)
        {
            return Dishes_orderDb.GetDishes_order(id);
        }

        public void AddDishes_order(int idDishe, int idLastOrder, int quantity)
        {
            Dishes_orderDb.AddDishes_order(idDishe, idLastOrder, quantity);
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
