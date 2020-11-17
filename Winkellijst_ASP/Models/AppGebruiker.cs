using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class AppGebruiker: IdentityUser
    {
        [PersonalData]
        public Gebruiker Gebruiker { get; set; }
    }
}
