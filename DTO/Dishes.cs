using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dishes
    {
        public int idDishes { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public int idRestaurant { get; set; }
    }
}
