using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class Gebruiker
    {
        public int GebruikerId { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public int UserId { get; set; } // foreign key naar leggen in fluent api
        public AppGebruiker AppGebruiker { get; set; }
    }
}
