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

        Availability AddAvailibility(Availability availibility);

        Availability UpdateAvailability(Availability availibility);

        Availability DeleteAvailability(int id);
    }
}
