using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICitiesDB
    {
        IConfiguration Configuration { get; }

        Cities AddCities (Cities cities);
        int DeleteCities(int id);
        Cities GetCity(int id);
        List<Cities> GetCities();
        int UpdateCities(Cities cities);
    }
}
