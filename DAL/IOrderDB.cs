using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IOrderDB
    {
        IConfiguration Configuration { get; }

        Order AddOrder(Order order);
        int DeleteOrder(int id);
        Order GetOrder(int id);
        int UpdateOrder(Order order);
    }
}
