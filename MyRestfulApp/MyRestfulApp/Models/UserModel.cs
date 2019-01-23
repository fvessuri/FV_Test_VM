using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestfulApp.Models
{
    public class UserModel
    {
        public string id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}