using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;
using System;

namespace DAL
{
    public interface IDeliveryDB
    {
        IConfiguration Configuration { get; }

        void AddDelivery(TimeSpan choosenTime, int idStaff);
        int DeleteDelivery (int id);
        Delivery GetDelivery(int id);
        int UpdateDelivery(Delivery delivery);
        int GetLastId();
    }
}
