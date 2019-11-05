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


        public Availability GetAvailibility(int id)
        {
            return AvailibilityDb.GetAvailability(id);
        }

        public Availability AddAvailibility(Availability availibility)
        {
            return AvailibilityDb.AddAvailability(availibility);
        }

        public int UpdateAvailability(Availability availibility)
        {
            return AvailibilityDb.UpdateAvailability(availibility);

        }

        public int DeleteAvailability(int id)
        {
            return AvailibilityDb.DeleteAvailability(id);
        }
    }
}
