using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class deliveryItem
    {
        public string dishesname { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string address { get; set; }

        public int idCity { get; set; }

        public TimeSpan deliveryTime { get; set; }

        public int Quantity { get; set; }

        public int idStaff { get; set; }

    }
}
