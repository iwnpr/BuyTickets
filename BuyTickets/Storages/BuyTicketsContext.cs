using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyTickets.Domains;
using Microsoft.EntityFrameworkCore;
    
namespace BuyTickets.Storages
{
    class BuyTicketsContext : DbContext
    {
        public BuyTicketsContext() => Database.EnsureCreated();
        
        public DbSet<Buyer> Buyers => Set<Buyer>();

        public DbSet<Ticket> Tickets => Set<Ticket>();

        public DbSet<Purchase> Purchases => Set<Purchase>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = BuyTicketsDb; Trusted_Connection = True; TrustServerCertificate = Yes");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
