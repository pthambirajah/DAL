using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class Credentials
    {
        public int idCredentials { get; set; }

        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Provide Password", AllowEmptyStrings = false)]
        public string password { get; set; }


    }
}
