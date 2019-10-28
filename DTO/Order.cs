using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order
    {
        public int idOrder { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
        public string idCustomer { get; set; }
        public int idDelivery { get; set; }
    }
}
