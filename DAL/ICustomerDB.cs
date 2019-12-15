using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICustomerDB
    {
        int GetCustomerIDByCredentials(int id);
        Customer AddCustomer(Customer customer);

        Customer GetCustomer (int id);
        Customer GetFirstnameLastname(int id);


    }
}
