using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class WinkelLijstProduct
    {
        public int WinkelLijstProductId { get; set; }
        public int Aantal { get; set; }
        public string Hoeveelheid { get; set; }
        public int WinkelLijstId { get; set; }
        public WinkelLijst WinkelLijst { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
