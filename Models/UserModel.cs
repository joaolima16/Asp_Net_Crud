using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserModel
    {
        public int ?Id { get; set; }
        public string ?Email {get;set;}

        public string ?Password { get; set; }
    }
}