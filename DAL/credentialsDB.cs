using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class CredentialsDB : ICredentialsDB
    {
        public IConfiguration Configuration { get; }
        public CredentialsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Credentials GetCredentials(int id)
        {
            Credentials credentials = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM credentials WHERE idCredentials = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            credentials = new Credentials();

                            credentials.idCredentials = (int)dr["idCredentials"];
                            credentials.username = (string)dr["username"];
                            credentials.password = (string)dr["password"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return credentials;
        }

        public Credentials AddCredentials(Credentials credentials)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO credentials(idCredentials, username, password) VALUES(@idCredentials, @username, @password); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCredentials", credentials.idCredentials);
                    cmd.Parameters.AddWithValue("@username", credentials.username);
                    cmd.Parameters.AddWithValue("@password", credentials.password);


                    cn.Open();

                    credentials.idCredentials = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return credentials;
        }

               
        //GET ID CREDENTIALS EN FONCTION D'UN USERNAME
        public int GetIdCredentials(string username)
        {
            int idCustomer = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select idCredentials from credentials WHERE username=@username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("username", username);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            idCustomer = (int)dr["idCredentials"];
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }
            return idCustomer;
        }

        //GET ID CREDENTIALS EN FONCTION D'UN USERNAME
        public bool isAdmin(string username)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            int accessLevel = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select status from credentials WHERE username=@username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("username", username);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            accessLevel = (int)dr["status"];
                        }

                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            if (accessLevel == 2)
                return true;
            else
                return false;
        }

        public string GetPassword(int idCredentials, string username)
        {
            string password = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select password from credentials WHERE idCredentials=@idCredentials AND username=@username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("idCredentials", idCredentials);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            password = (string)dr["password"];
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }
            return password;
        }


        //GET ID STAFF EN FONCTION D'UN USERNAME
        public int GetIdStaff(string username)
        {
            int idStaff = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT idStaff FROM staff INNER JOIN credentials c ON staff.FK_idCredentials = c.idCredentials WHERE c.username = @username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("username", username);

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

        public bool isStaff (string username)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            int accessLevel = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select status from credentials WHERE username=@username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("username", username);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            accessLevel = (int)dr["status"];
                        }

                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            if (accessLevel == 1)
                return true;
            else
                return false;
        }

    }
}
