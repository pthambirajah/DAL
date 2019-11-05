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


        public Cities GetCities(int id)
        {
            return CitiesDb.GetCities(id);
        }

        public Cities AddCities(Cities cities)
        {
            return CitiesDb.AddCities(cities);
        }

        public int UpdateCities(Cities cities)
        {
            return CitiesDb.UpdateCities(cities);

        }

        public int DeleteCities(int id)
        {
            return CitiesDb.DeleteCities(id);
        }
    }
}
