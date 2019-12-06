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

        [Required]
        public string UserName { get; set; }

        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        public string Gender { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
