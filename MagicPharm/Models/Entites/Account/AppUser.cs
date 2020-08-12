using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Entites.Account
{
    public class AppUser : IdentityUser
    {

        [Display(Name = " מספר טלפון אחר")]
        public string PhoneNumber2 { get; set; }

        [NotMapped]
        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
