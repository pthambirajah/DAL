    using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class AvailabilityDB : IAvailabilityDB
    {
        private IConfiguration Configuration { get; }
        public AvailabilityDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Retrieve available delivery time of the staff who works in the same city as the restaurant given in parameter.
        public List<Availability> GetAvailabilitiesByRestaurant(int id)
        {
            List<Availability> availability = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT DISTINCT idAvailability, time, a.idStaff FROM availibility a INNER JOIN staff s ON a.idStaff = s.idStaff INNER JOIN restaurants r ON s.FK_iDCity = r.idCity WHERE r.idRestaurant = @id and isAvailable = 1 and s.FK_iDCity = r.idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (availability == null)
                                availability = new List<Availability>();

                            Availability available = new Availability();
                            available.idAvailability = (int)dr["idAvailability"];
                            available.time = (TimeSpan)dr["time"];
                            available.idStaff = (int)dr["idStaff"];

                            availability.Add(available);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return availability;
        }


        //Update the availiility of a given idAvailability 
        public void UpdateAvailability(int id)
        {
           // int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    

                    string query = "UPDATE availibility SET isAvailable = 0 WHERE idAvailability=@idAvailability";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idAvailability", id);
             
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*Reset all availibilities and counters
         * Reset the counter to 0 if it is not equals to zero
         * Reset the isAvailable to 1 if it is equal to zero
         */

        public void ResetAvailability()
        {
            // int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE availibility SET countr = 0, isAvailable = 1  WHERE isAvailable = 0 OR countr != 0";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //method to get the counter
        public int GetCounter(int id)
        {
            int nbcounter = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT countr FROM availibility WHERE idAvailability = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            nbcounter = (int)dr["countr"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return nbcounter;
        }

        //method to increment the counter of a given availibility
        public void IncrementCounter(int id)
        {
            int nbcountr = GetCounter(id)+1;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE availibility SET countr = @nbcountr WHERE idAvailability=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nbcountr", nbcountr);
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

        //method to decrement the counter of a given availibility
        public void DecrementCounter(int id)
        {
            int nbcountr = GetCounter(id) - 1;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE availibility SET countr = @nbcountr WHERE idAvailability=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nbcountr", nbcountr);
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

      
        //
        public void ResetAvailability(int id)
        {
            // int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE availibility SET isAvailable = 1  WHERE isAvailable = 0 AND idAvailability = @id ";
                    SqlCommand cmd = new SqlCommand(query, cn);

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
