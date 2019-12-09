using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class deliveryItem
    {

        public Dishes Dishe { get; set; }
        public Customer Customer { get; set; }

        public Delivery Delivery { get; set; }

    }
}
