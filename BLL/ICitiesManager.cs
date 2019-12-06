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

        Cities AddCities(Cities cities);
        Cities UpdateCities(Cities cities);
        List<Cities> GetCities();
        Cities DeleteCities(int id);
    }
}
