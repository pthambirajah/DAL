using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface IDeliveryManager
    {

        IDeliveryDB DeliveryDB { get; }

        Delivery AddDelivery(TimeSpan choosenTime, int idStaff);

        Delivery UpdateDelivery(Delivery delivery);

        Delivery DeleteDelivery(int id);

        int GetLastId();
    }
}
