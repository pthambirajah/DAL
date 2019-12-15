using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class CustomerManager
    {
        private CustomerDB CustomerDb { get; }


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

        public Customer GetFirstnameLastname(int id)
        {
            return CustomerDb.GetFirstnameLastname(id);
        }
    }
}
