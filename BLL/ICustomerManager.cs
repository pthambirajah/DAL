using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface ICustomerManager
    {
        Customer AddCustomer(Customer customer);

        int GetCustomerIDByCredentials(int id);
        Customer GetFirstnameLastname(int id);



    }
}
