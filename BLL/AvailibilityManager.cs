using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;
namespace BLL
{
    public class AvailibilityManager
    {
        private AvailabilityDB AvailibilityDb { get; }


        public AvailibilityManager(IConfiguration configuration)
        {
            AvailibilityDb = new AvailabilityDB(configuration);
        }

        public Availability IsAvailable(int idStaff, TimeSpan deliveryTime)
        {
            return AvailibilityDb.IsAvailable(idStaff, deliveryTime);
        }


        public List<Availability> GetAvailabilitiesByRestaurant(int id)
        {
            return AvailibilityDb.GetAvailabilitiesByRestaurant(id);
        }

        public void ResetAvailability()
        {
            AvailibilityDb.ResetAvailability();
        }
        public void UpdateAvailability(int id, int status)
        {
            AvailibilityDb.UpdateAvailability(id, status);
        }

        public void DecrementCounter(int id)
        {
            AvailibilityDb.DecrementCounter(id);
        }

        public void IncrementCounter(int id)
        {
            AvailibilityDb.IncrementCounter(id);        
        }
        public int GetCounter(int id)
        {
            return AvailibilityDb.GetCounter(id);
        }

    }
}
