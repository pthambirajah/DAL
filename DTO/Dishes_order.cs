using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dishes_order
    {

        public int idDishes_Order { get; set; }
        public int idDishes { get; set; }
        public int idOrder { get; set; }
        public int quantity { get; set; }
    }
}
