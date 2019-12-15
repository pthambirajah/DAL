using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Customer
    {
        public int idCustomer { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime birthdate { get; set; }
        public string address { get; set; }
        public int idCity { get; set; }
        public int idCredentials { get; set; }




    }
}
