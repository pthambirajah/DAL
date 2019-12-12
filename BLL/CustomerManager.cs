using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class CustomerManager
    {
        public CustomerDB CustomerDb { get; }


        public CustomerManager(IConfiguration configuration)
        {
            CustomerDb = new CustomerDB(configuration);
        }
        public int GetCustomerIDByCredentials(int id)
        {
            return CustomerDb.GetCustomerIDByCredentials(id);
        }

        public Customer GetCustomer(int id)
        {
            return CustomerDb.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDb.AddCustomer(customer);
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomerDb.UpdateCustomer(customer);

        }

        public int DeleteCustomer(int id)
        {
            return CustomerDb.DeleteCustomer(id);
        }
    }
}
