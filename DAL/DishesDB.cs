using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class DishesDB : IDishesDB
    {
        public IConfiguration Configuration { get; }
        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Order GetDishes(int id)
        {
            Dishes dishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM dishes WHERE idDishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dishes = new Dishes();

                            dishes.idDishes = (int)dr["idDishes"];
                            dishes.name = (string)dr["name"];
                            dishes.price = (string)dr["price"];
                            dishes.status = (string)dr["status"];
                            dishes.idRestaurant = (int)dr["idRestaurant"];


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }

        public Dishes AddDishes(Dishes dishes)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dishes(name, price, status, idRestaurant) VALUES(@name, @price, @status, @idRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dishes.name);
                    cmd.Parameters.AddWithValue("@price", dishes.price);
                    cmd.Parameters.AddWithValue("@status", dishes.status);
                    cmd.Parameters.AddWithValue("@idRestaurant", dishes.idRestaurant);

                    cn.Open();

                    dishes.idDishes = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }

        public int UpdateDishes(Dishes dishes)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dishes SET name=@name, price=@price, status=@status, idRestaurant=@idRestaurant WHERE idOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dishes.name);
                    cmd.Parameters.AddWithValue("@price", dishes.price);
                    cmd.Parameters.AddWithValue("@status", dishes.status);
                    cmd.Parameters.AddWithValue("@idRestaurant", dishes.idRestaurant);

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

        public int DeleteDishes(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM dishes WHERE idDishesr=@id";
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
