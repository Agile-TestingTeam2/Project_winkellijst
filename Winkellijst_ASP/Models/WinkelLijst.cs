using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class WinkelLijst
    {
        public int WinkelLijstId { get; set; }
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int WinkelId { get; set; }
        public Winkel Winkel { get; set; }
        public DateTime AanmaakDatum { get; set; }
    }
}
