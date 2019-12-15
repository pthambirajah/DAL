using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        private IConfiguration Configuration { get; }
        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Method to get all cities

        public List<Cities> GetCities()
        {
            List<Cities> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Cities>();

                            Cities city = new Cities();

                            city.idCity = (int)dr["idCity"];
                            city.city = (string)dr["city"];
                            city.post_code = (string)dr["post_code"];

                            results.Add(city);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        //Method to get a city by its given parameter
        public Cities GetCity(int id)
        {
            Cities cities = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM cities WHERE idCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cities = new Cities();

                            cities.idCity = (int)dr["idCity"];
                            cities.city = (string)dr["city"];
                            cities.post_code = (string)dr["post_code"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return cities;
        }

    } 
}
