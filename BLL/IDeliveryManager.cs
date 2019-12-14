using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface IDeliveryManager
    {
        Delivery AddDelivery(TimeSpan choosenTime, int idStaff);

        int GetLastId();
    }
}
