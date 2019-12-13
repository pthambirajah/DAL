using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;
namespace BLL
{
    public class CitiesManager
    {
        public CitiesDB CitiesDb { get; }


        public CitiesManager(IConfiguration configuration)
        {
            CitiesDb = new CitiesDB(configuration);
        }

        public List<Cities> GetCities()
        {
            return CitiesDb.GetCities();
        }
        public Cities GetCity(int id)
        {
            return CitiesDb.GetCity(id);
        }

    }
}
