using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class Dishes_orderDB : IDishes_orderDB
    {
        public IConfiguration Configuration { get; }
        public Dishes_orderDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Dishes_order GetDishes_order(int id)
        {
            Dishes_order dishes_order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM dishes_order WHERE idDishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dishes_order = new Dishes_order();

                            dishes_order.idDishes_Order = (int)dr["idDishes_Order"];
                            dishes_order.idDishes = (int)dr["idDishes"];
                            dishes_order.idOrder = (int)dr["idOrder"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes_order;
        }

        public Dishes_order AddDishes_order(Dishes_order dishes_order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dishes_order(idDishes, idDishes_Order, idOrder) VALUES(@idDishes, @idDishes_Order, @idOrder); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idDishes", dishes_order.idDishes);
                    cmd.Parameters.AddWithValue("@idDishes_Order", dishes_order.idDishes_Order);
                    cmd.Parameters.AddWithValue("@idOrder", dishes_order.idOrder);

                    cn.Open();

                    dishes_order.idDishes_Order = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes_order;
        }

        public int UpdateDishes_order(Dishes_order dishes_order)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dishes_order SET name=@name, idDishes=@idDishes, idDishes_Order=@idDishes_Order, idOrder=@idOrder WHERE idDishes_Order=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idDishes", dishes_order.idDishes);
                    cmd.Parameters.AddWithValue("@idDishes_Order", dishes_order.idDishes_Order);
                    cmd.Parameters.AddWithValue("@idOrder", dishes_order.idOrder);

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

        public int DeleteDishes_order(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM dishes_order WHERE idDishes_order=@id";
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

        public Dishes_order GetDishes_orderByStaff(int id)
        {
            Dishes_order dishes_order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT delivery.idStaff FROM dishes_order d INNER JOIN order o ON o.idOrder = d.idOrder INNER JOIN delivery ON delivery.idDelivery = o.idDelivery";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dishes_order = new Dishes_order();

                            dishes_order.idDishes_Order = (int)dr["idDishes_Order"];
                            dishes_order.idDishes = (int)dr["idDishes"];
                            dishes_order.idOrder = (int)dr["idOrder"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes_order;
        }
    }
}
