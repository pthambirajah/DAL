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
            public IConfiguration Configuration { get; }
            public CitiesDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }


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

            public Cities AddCities(Cities cities)
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO cities(idCity, city, post_code) VALUES(@idCity, @city, @post_code); SELECT SCOPE_IDENTITY()";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@idCity", cities.idCity);
                        cmd.Parameters.AddWithValue("@city", cities.city);
                        cmd.Parameters.AddWithValue("@post_code", cities.post_code);


                        cn.Open();

                    cities.idCity = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return cities;
            }

            public int UpdateCities (Cities cities)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE cities SET idCity=@idCity, city=@city, post_code=@post_code WHERE idCity=@idCity";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@idAvailability", cities.idCity);
                        cmd.Parameters.AddWithValue("@city", cities.city);
                        cmd.Parameters.AddWithValue("@post_code", cities.post_code);

                        cn.Open();

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return result;
            }

            public int DeleteCities(int id)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM cities WHERE idCity=@idCity";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@idCity", id);

                        cn.Open();

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return result;
            }
        }
}
