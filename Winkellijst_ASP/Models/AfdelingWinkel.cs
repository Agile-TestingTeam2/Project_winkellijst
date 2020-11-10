using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class AfdelingWinkel
    {
        public int AfdelingWinkelId { get; set; }
        public int AfdelingId { get; set; }
        public Afdeling Afdeling { get; set; }
        public int WinkelId { get; set; }
        public Winkel Winkel { get; set; }
        public int Volgorde { get; set; }
        public ICollection<WinkelLijst> WinkelLijsten { get; set; }
    }
}
