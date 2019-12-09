using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class deliveryItem
    {

        public Dishes Dishes { get; set; }
        public Customer Customer { get; set; }

        public Delivery Delivery { get; set; }

    }
}
