using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Cities
    {
        public int idCity { get; set; }
        public string city { get; set; }
        public string post_code { get; set; }
        /*
        public static implicit operator Cities(global::DAL.CitiesDB v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Cities(global::DAL.CitiesDB v)
        {
            throw new NotImplementedException();
        }*/
    }
}
