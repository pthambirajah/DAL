using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICitiesDB
    {
        IConfiguration Configuration { get; }
        Cities GetCity(int id);
        List<Cities> GetCities();

    }
}
