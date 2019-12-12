using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IAvailabilityDB
    {
        IConfiguration Configuration { get; }

        List<Availability> GetAvailabilitiesByRestaurant(int id);
        int DeleteAvailability(int id);
        Availability GetAvailability(int id);
        void UpdateAvailability(int id);
    }
}
