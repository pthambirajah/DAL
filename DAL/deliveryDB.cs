using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class DeliveryDB : IDeliveryDB
    {
        
            public IConfiguration Configuration { get; }
            public DeliveryDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }


            public Delivery GetDelivery(int id)
            {
                Delivery delivery = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM delivery WHERE idDelivery = @id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                delivery = new Delivery();

                                delivery.idDelivery = (int)dr["idDelivery"];
                                delivery.deliveryTime = (DateTime)dr["deliveryTime"];
                                delivery.idStaff = (int)dr["idStaff"];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return delivery;
            }

            public Delivery AddDelivery(Delivery delivery)
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO delivery (idDelivery, deliveryTime, idStaff) VALUES(@idDelivery, @deliveryTime, @idStaff); SELECT SCOPE_IDENTITY()";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@idDelivery", delivery.idDelivery);
                        cmd.Parameters.AddWithValue("@deliveryTime", delivery.deliveryTime);
                        cmd.Parameters.AddWithValue("@idStaff", delivery.idStaff);

                        cn.Open();

                        delivery.idDelivery = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return delivery;
            }

            public int UpdateDelivery(Delivery delivery)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE delivery SET idDelivery=@idDelivery, idDishes=@idDishes, deliveryTime=@deliveryTime, idStaff=@idStaff WHERE idDelivery=@idDelivery";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@idDelivery", delivery.idDelivery);
                        cmd.Parameters.AddWithValue("@idDishes_Order", delivery.deliveryTime);
                        cmd.Parameters.AddWithValue("@idOrder", delivery.idStaff);

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

            public int DeleteDelivery(int id)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM delivery WHERE idDelivery=@idDelivery";
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


