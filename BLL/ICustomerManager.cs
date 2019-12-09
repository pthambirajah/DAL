﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface ICustomerManager
    {
        ICustomerDB CustomerDB { get; }

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        Customer DeleteCustomer(int id);
    }
}