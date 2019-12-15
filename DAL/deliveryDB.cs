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

        private IConfiguration Configuration { get; }
            public DeliveryDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }
  

        public int GetLastId()
        {
            int lastDelivery = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT idDelivery FROM delivery WHERE idDelivery = (SELECT max(idDelivery) FROM delivery)";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lastDelivery = (int)dr["idDelivery"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return lastDelivery;
        }

        public void AddDelivery(TimeSpan choosenTime, int idStaff)
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO delivery (deliveryTime, idStaff, deliveryDate) VALUES(@deliveryTime, @idStaff, GETDATE())";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@deliveryTime", choosenTime);
                        cmd.Parameters.AddWithValue("@idStaff", idStaff);

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


