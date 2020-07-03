using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Signup

    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int MobNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool AccountType { get; set; }

    }
    

}
