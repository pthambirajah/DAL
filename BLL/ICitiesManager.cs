using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICitiesManager
    {
        ICitiesDB CitiesDB { get; }

        List<Cities> GetCities();
    
    }
}
