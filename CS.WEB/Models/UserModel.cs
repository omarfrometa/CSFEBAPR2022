using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS.WEB.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> PlaceBirthId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
}