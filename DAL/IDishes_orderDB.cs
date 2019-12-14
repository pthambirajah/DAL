using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IDishes_orderDB
    {
        void AddDishes_order(int idDishe, int idLastOrder, int quantity);
        List<deliveryItem> GetDishes_orderByStaff(int id);

        List<deliveryItem> GetDishes_orderByCustomer(int id);
        void UpdateOrderStatus(int id);

        void UpdateOrderStatusToCancel(int id);

    }
}
