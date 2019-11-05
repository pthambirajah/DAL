using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IDeliveryDB
    {
        IConfiguration Configuration { get; }

        Delivery AddDelivery(Delivery delivery);
        int DeleteDelivery (int id);
        Delivery GetDelivery(int id);
        int UpdateDelivery(Delivery delivery);
    }
}
