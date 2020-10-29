using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Winkellijst_ASP.Data
{
    public class GebruikerContext : DbContext
    {
        public GebruikerContext (DbContextOptions<GebruikerContext> options)
            : base(options)
        {

        }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
        }
    }
}
