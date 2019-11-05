using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class CustomerDB : ICustomerDB
    {

        public IConfiguration Configuration { get; }
        public CustomerDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM customer WHERE idCustomer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer = new Customer();

                            customer.idCustomer = (int)dr["idCustomer"];
                            customer.lastname = (string)dr["lastname"];
                            customer.firstname = (string)dr["firstname"];
                            customer.birthdate = (DateTime)dr["birthdate"];
                            customer.address = (string)dr["address"];
                            customer.idCity = (int)dr["idCity"];
                            customer.idCredentials = (int)dr["idCredentials"];


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO availability(idCustomer, lastname, firstname, birthdate, address, idCity, idCredentials) VALUES(@idCustomer, @lastname, @firstname, @birthdate, @address, @idCity, @idCredentials); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomer", customer.idCustomer);
                    cmd.Parameters.AddWithValue("@lastname", customer.lastname);
                    cmd.Parameters.AddWithValue("@firstname", customer.firstname);
                    cmd.Parameters.AddWithValue("@birthdate", customer.birthdate);
                    cmd.Parameters.AddWithValue("@address", customer.address);
                    cmd.Parameters.AddWithValue("@idStaff", customer.idCity);
                    cmd.Parameters.AddWithValue("@idStaff", customer.idCredentials);


                    cn.Open();

                    customer.idCustomer = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public int UpdateCustomer(Customer customer)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE customer SET idCustomer=@idCustomer, lastname=@lastname, firstname=@firstname, birthdate=@birthdate, address=@address,  idCity=@idCity, idCredentials=@idCredentials WHERE idCustomer=@idCustomer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomer", customer.idCustomer);
                    cmd.Parameters.AddWithValue("@lastname", customer.lastname);
                    cmd.Parameters.AddWithValue("@firstname", customer.firstname);
                    cmd.Parameters.AddWithValue("@birthdate", customer.birthdate);
                    cmd.Parameters.AddWithValue("@address", customer.address);
                    cmd.Parameters.AddWithValue("@idCity", customer.idCity);
                    cmd.Parameters.AddWithValue("@idCredentials", customer.idCredentials);


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

        public int DeleteCustomer(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM customer WHERE idCustomer=@idCustomer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomer", id);

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
