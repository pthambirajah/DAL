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

        public int GetLastId()
        {
            return DeliveryDb.GetLastId();
        }

        public void AddDelivery(TimeSpan choosenTime, int idStaff)
        {
            DeliveryDb.AddDelivery(choosenTime, idStaff);
        }


    }
}
