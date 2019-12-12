﻿using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICustomerDB
    {
        IConfiguration Configuration { get; }
        int GetCustomerIDByCredentials(int id);
        Customer AddCustomer(Customer customer);
        int DeleteCustomer (int id);
        Customer GetCustomer (int id);
        int UpdateCustomer(Customer customer);
    }
}
