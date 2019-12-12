using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IOrderDB
    {
        IConfiguration Configuration { get; }

        void AddOrder(int idCustomer, int idDelivery);
        int DeleteOrder(int id);
        Order GetOrder(int id);
        int GetLastId();
        int UpdateOrder(Order order);


    }
}
