using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class StaffDB : IStaffDB
    {
        public IConfiguration Configuration { get; }
        public StaffDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //method to get a staffid by its given IdCredential
        public int GetStaffId(int id)
        {
            int idStaff = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT idStaff FROM staff WHERE FK_idCredentials = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {


                            idStaff = (int)dr["idStaff"];
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return idStaff;
        }

        //method to get a staff by its given id
        public Staff GetStaff(int id)
        {
            Staff staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM staff WHERE IdStaff = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                        
                            staff.idStaff = (int)dr["IdStaff"];
                            staff.name = (string)dr["name"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }

        //method to add a staff by its given id
        public Staff AddStaff(Staff staff)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO staff(name) VALUES(@name); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", staff.name);

                    cn.Open();

                    staff.idStaff = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }

        //method to update a Staff
        public int UpdateStaff(Staff staff)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE staff SET name=@name WHERE idStaff=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", staff.idStaff);
                    cmd.Parameters.AddWithValue("@name", staff.name);

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

        //method to delete a staff by its given id
        public int DeleteStaff(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM staff WHERE idStaff=@id";
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
