using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Availability
    {
        public int idAvailability { get; set; }
        
        public Boolean isAvailable { get; set; }

        public DateTime time { get; set; }

        public int idStaff { get; set; }


    }
}
