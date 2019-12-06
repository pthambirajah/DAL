using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class RestaurantDB : IRestaurantDB
    {
        public IConfiguration Configuration { get; }
        public RestaurantDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM restaurants";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.idRestaurant = (int)dr["idRestaurant"];
                            restaurant.merchant_name = (string)dr["merchant_name"];
                            restaurant.createdAt = (string)dr["createdAt"];
                            restaurant.idCity = (int)dr["idCity"];

                            results.Add(restaurant);
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

        public Restaurant GetRestaurant(int id)
        {
            Restaurant restaurant = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM restaurants WHERE idRestaurant = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurant();

                            restaurant.idRestaurant = (int)dr["idRestaurant"];
                            restaurant.merchant_name = (string)dr["merchant_name"];
                            restaurant.createdAt = (string)dr["createdAt"];
                            restaurant.idCity = (int)dr["idCity"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO restaurants(merchant_name, createdAt, idCity) VALUES(@merchant_name, @createdAt, @idCity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", restaurant.merchant_name);
                    cmd.Parameters.AddWithValue("@description", restaurant.createdAt);
                    cmd.Parameters.AddWithValue("@location", restaurant.idCity);

                    cn.Open();

                    restaurant.idRestaurant = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE restaurants SET merchant_name=@merchant_name, createdAt=@createdAt, idCity=@idCity WHERE idRestaurant=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", restaurant.merchant_name);
                    cmd.Parameters.AddWithValue("@description", restaurant.createdAt);
                    cmd.Parameters.AddWithValue("@location", restaurant.idCity);

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

        public int DeleteRestaurant(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM restaurants WHERE idRestaurant=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

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
