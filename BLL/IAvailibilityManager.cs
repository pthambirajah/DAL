using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface IAvailibilityManager
    {
        IAvailabilityDB AvailabilityDB { get; }

        List<Availability> GetAvailabilitiesByRestaurant(int id);

        Availability AddAvailibility(Availability availibility);

        void UpdateAvailability(int id);

        void ResetAvailability();
        void IncrementCounter(int id);
        int GetCounter(int id);
    }
}
