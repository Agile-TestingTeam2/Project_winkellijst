using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Naam { get; set; }
        public ICollection<Afdeling> Afdelingen { get; set; }
        public ICollection<WinkelLijst> WinkelLijsten { get; set; }
    }
}
