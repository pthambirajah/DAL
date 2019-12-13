using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Availability
    {
        public int idAvailability { get; set; }
        
        public Boolean isAvailable { get; set; }

        public TimeSpan time { get; set; }

        public int idStaff { get; set; }
        public int countr { get; set; }


    }
}
