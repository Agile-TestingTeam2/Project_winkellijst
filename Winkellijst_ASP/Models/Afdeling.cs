using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class Afdeling
    {
        public int AfdelingId { get; set; }
        public string Naam { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<AfdelingWinkel> afdelingWinkels { get; set; }
    }
}
