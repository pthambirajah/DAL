﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class AvailabilityDB : IAvailabilityDB
    {
        public IConfiguration Configuration { get; }
        public AvailabilityDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Availability GetAvailability(int id)
        {
            Availability availability = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM availability WHERE idAvailability = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            availability = new Availability();

                            availability.idAvailability = (int)dr["idAvailability"];
                            availability.isAvailable = (Boolean)dr["isAvailable"];
                            availability.time = (TimeSpan)dr["time"];
                            availability.idStaff = (int)dr["idStaff"];
                            
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

        public void UpdateAvailability(int id)
        {
           // int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE availability SET isAvailable=0 WHERE idAvailability=@idAvailability";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idAvailability", id);
             
                    cn.Open();

                   //result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int DeleteAvailability(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM availability WHERE idAvailability=@idAvailability";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idAvailability", id);

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
