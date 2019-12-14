using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;
using System;

namespace DAL
{
    public interface IDeliveryDB
    {
        void AddDelivery(TimeSpan choosenTime, int idStaff);
        int GetLastId();
    }
}
