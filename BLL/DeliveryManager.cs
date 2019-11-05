using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class DeliveryManager
    {
        public DeliveryDB DeliveryDb { get; }


        public DeliveryManager(IConfiguration configuration)
        {
            DeliveryDb = new DeliveryDB(configuration);
        }


        public Delivery GetDelivery(int id)
        {
            return DeliveryDb.GetDelivery(id);
        }

        public Delivery AddDelivery(Delivery delivery)
        {
            return DeliveryDb.AddDelivery(delivery);
        }

        public int UpdateDelivery(Delivery delivery)
        {
            return DeliveryDb.UpdateDelivery(delivery);

        }

        public int DeleteDelivery(int id)
        {
            return DeliveryDb.DeleteDelivery(id);
        }

    }
}
