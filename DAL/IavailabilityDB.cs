using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IAvailabilityDB
    {
        IConfiguration Configuration { get; }

        List<Availability> GetAvailabilitiesByRestaurant(int id);

        void UpdateAvailability(int id);

        void IncrementCounter(int id);
        int GetCounter(int id);

        void ResetAvailability();

    }
}
