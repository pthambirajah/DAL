using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IAvailabilityDB
    {
        IConfiguration Configuration { get; }


        Availability AddAvailability(Availability availability);
        int DeleteAvailability(int id);
        Availability GetAvailability(int id);
        int UpdateAvailability(Availability availability);
    }
}
