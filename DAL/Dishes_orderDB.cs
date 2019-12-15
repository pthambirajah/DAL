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
        private IConfiguration Configuration { get; }
        public Dishes_orderDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void AddDishes_order(int idDishe, int idLastOrder, int quantity)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dishes_order(idDishes, idOrder, quantity) VALUES(@idDishe, @idOrder, @quantity)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idDishe", idDishe);
                    cmd.Parameters.AddWithValue("@idOrder", idLastOrder);
                    cmd.Parameters.AddWithValue("@quantity", quantity);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    // dishes_order.idDishes_Order = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<deliveryItem> GetDishes_orderByStaff(int id)
        {
            List<deliveryItem> deliveryBundle = null;
            var name = "";
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT m.name, c.lastname, c.firstname, c.address, c.idCity, delivery.deliveryTime, d.quantity, o.idOrder, o.status FROM dishes_order d INNER JOIN commande o ON o.idOrder = d.idOrder INNER JOIN delivery ON delivery.idDelivery = o.idDelivery INNER JOIN dishes m ON m.idDishes=d.idDishes INNER JOIN customer c ON c.idCustomer = o.idCustomer  WHERE delivery.idStaff= @id AND delivery.deliveryDate=CAST(getdate() AS date)";
                    
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (deliveryBundle == null)
                                deliveryBundle = new List<deliveryItem>();

                            deliveryItem deliveryItem = new deliveryItem();

                            deliveryItem.dishesname = (string)dr["name"];
                            deliveryItem.lastname = (string)dr["lastname"];
                            deliveryItem.firstname = (string)dr["firstname"];
                            deliveryItem.address = (string)dr["address"];
                            deliveryItem.idCity = (int)dr["idCity"];
                            deliveryItem.deliveryTime = (TimeSpan)dr["deliveryTime"];
                            if (dr["quantity"] != null)
                            {
                                deliveryItem.Quantity = (int)dr["quantity"];
                            }
                            deliveryItem.idOrder = (int)dr["idOrder"];
                            deliveryItem.status = (string)dr["status"];

                            deliveryBundle.Add(deliveryItem);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliveryBundle;
        }

        public List<deliveryItem> GetDishes_orderByCustomer(int id)
        {
            List<deliveryItem> deliveryBundle = null;
           
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT m.name, delivery.deliveryTime, d.quantity, o.idOrder, o.status FROM dishes_order d INNER JOIN commande o ON o.idOrder = d.idOrder INNER JOIN delivery ON delivery.idDelivery = o.idDelivery INNER JOIN dishes m ON m.idDishes=d.idDishes INNER JOIN customer c ON c.idCustomer = o.idCustomer  WHERE o.idCustomer = @id ORDER BY o.idOrder";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (deliveryBundle == null)
                                deliveryBundle = new List<deliveryItem>();

                            deliveryItem deliveryItem = new deliveryItem();

                            deliveryItem.dishesname = (string)dr["name"];
                            deliveryItem.deliveryTime = (TimeSpan)dr["deliveryTime"];
                            deliveryItem.Quantity = (int)dr["quantity"];
                            deliveryItem.idOrder = (int)dr["idOrder"];
                            deliveryItem.status = (string)dr["status"];

                            deliveryBundle.Add(deliveryItem);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliveryBundle;
        }

        public void UpdateOrderStatus(int id)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE commande SET status = 'archived' WHERE idOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void UpdateOrderStatusToCancel(int id)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE commande SET status = 'cancelled' WHERE idOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
