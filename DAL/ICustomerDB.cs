using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICustomerDB
    {
        IConfiguration Configuration { get; }
        int GetCustomerIDByCredentials(int id);
        Customer AddCustomer(Customer customer);

        Customer GetCustomer (int id);

    }
}
