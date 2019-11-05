using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface ICitiesManager
    {
        ICitiesDB CitiesDB { get; }

        Cities AddCities(Cities cities);
        Cities UpdateCities(Cities cities);

        Cities DeleteCities(int id);
    }
}
