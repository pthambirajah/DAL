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

        [DisplayName("Username")] //changing the default "UserName" by putting a space (called in the view)
        [Required(ErrorMessage = "This field is required.")]
        public string username { get; set; }

        [DisplayName("Password")] //changing the default "UserName" by putting a space (called in the view)
        [DataType(DataType.Password)] //so what we type is hidden behind the usual "dots"
        [Required(ErrorMessage = "This field is required.")]
        public string password { get; set; }


    }
}
