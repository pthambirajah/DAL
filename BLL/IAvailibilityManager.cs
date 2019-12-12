﻿using System;
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

        Availability UpdateAvailability(int id);

        Availability DeleteAvailability(int id);
    }
}
