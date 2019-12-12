using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveAble.Model
{
    public class People
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }


      
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName should not be empty")]
        public string UserName { get; set; }
       

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email should not be empty")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password should not be empty")]
        public string Password { get; set; }
       

    }
}
