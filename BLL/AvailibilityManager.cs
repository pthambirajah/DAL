using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;
namespace BLL
{
    public class AvailibilityManager
    {
        public AvailabilityDB AvailibilityDb { get; }


        public AvailibilityManager(IConfiguration configuration)
        {
            AvailibilityDb = new AvailabilityDB(configuration);
        }


        public List<Availability> GetAvailabilitiesByRestaurant(int id)
        {
            return AvailibilityDb.GetAvailabilitiesByRestaurant(id);
        }
     

        public void UpdateAvailability(int id)
        {
            AvailibilityDb.UpdateAvailability(id);
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
