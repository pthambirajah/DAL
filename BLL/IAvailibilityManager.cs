using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface IAvailibilityManager
    {
        List<Availability> GetAvailabilitiesByRestaurant(int id);

        void UpdateAvailability(int id, int status);

        void ResetAvailability();
        void IncrementCounter(int id);
        int GetCounter(int id);

        void DecrementCounter(int id);
        Availability IsAvailable(int idStaff, TimeSpan deliveryTime);
    }
}
