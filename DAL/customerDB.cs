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

        public int GetCustomerIDByCredentials(int id)
        {
            int iDCustomer = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT idCustomer FROM customer WHERE idCredentials = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                           iDCustomer = (int)dr["idCustomer"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return iDCustomer;
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

    }
}
