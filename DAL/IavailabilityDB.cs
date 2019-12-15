using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;
using System;

namespace DAL
{
    public interface IAvailabilityDB
    {
        List<Availability> GetAvailabilitiesByRestaurant(int id);

        void UpdateAvailability(int id, int status);

        void IncrementCounter(int id);
        int GetCounter(int id);

        void ResetAvailability();

        void DecrementCounter(int id);

        Availability IsAvailable(int idStaff, TimeSpan deliveryTime);

    }
}
