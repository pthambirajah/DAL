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
                            availability.time = (DateTime)dr["time"];
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

        public Availability AddAvailability(Availability availability)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO availability(idAvailability, isAvailable, time, idStaff) VALUES(@idAvailability, @isAvailable, @time, @idStaff); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idAvailability", availability.idAvailability);
                    cmd.Parameters.AddWithValue("@isAvailable", availability.isAvailable);
                    cmd.Parameters.AddWithValue("@time", availability.time);
                    cmd.Parameters.AddWithValue("@idStaff", availability.idStaff);


                    cn.Open();

                    availability.idAvailability = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return availability;
        }

        public int UpdateAvailability(Availability availability)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE availability SET idAvailability=@idAvailability, isAvailable=@isAvailable, time=@time, idStaff=@idStaff WHERE idAvailability=@idAvailability";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idAvailability", availability.idAvailability);
                    cmd.Parameters.AddWithValue("@isAvailable", availability.isAvailable);
                    cmd.Parameters.AddWithValue("@time", availability.time);
                    cmd.Parameters.AddWithValue("@idStaff", availability.idStaff);

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
