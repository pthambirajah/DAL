using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class OrderDB : IOrderDB
    {
        public IConfiguration Configuration { get; }
        public OrderDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Order GetOrder(int id)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM order WHERE idOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Order();

                            order.idOrder = (int)dr["idOrder"];
                            order.status = (string)dr["status"];
                            order.createdAt = (string)dr["createdAt"];
                            order.idCustomer = (int)dr["idCustomer"];
                            order.idDelivery = (int)dr["idDelivery"];


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public Order AddOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO order(status, createdAt, idCustomer, idDelivery) VALUES(@status, @createdAt, @idCustomer, @idDelivery); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@createdAt", order.createdAt);
                    cmd.Parameters.AddWithValue("@idCustomer", order.idCustomer);
                    cmd.Parameters.AddWithValue("@idDelivery", order.idDelivery);

                    cn.Open();

                    order.idOrder = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE restaurant SET status=@status, createdAt=@createdAt, idCustomer=@idCustomer, idDelivery=@idDelivery WHERE idOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@createdAt", order.createdAt);
                    cmd.Parameters.AddWithValue("@idCustomer", order.idCustomer);
                    cmd.Parameters.AddWithValue("@idDelivery", order.idDelivery);

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

        public int DeleteOrder(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM order WHERE idOrder=@id";
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
