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

        public int UpdateCredentials(Credentials credentials)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE credentials SET idCredentials=@idCredentials, username=@username, password=@password WHERE idCredentials=@idCredentials";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCredentials", credentials.idCredentials);
                    cmd.Parameters.AddWithValue("@username", credentials.username);
                    cmd.Parameters.AddWithValue("@password", credentials.password);

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

        public int DeleteCredentials(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM credentials WHERE idCredentials=@idCredentials";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCredentials", id);

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

    }
}
