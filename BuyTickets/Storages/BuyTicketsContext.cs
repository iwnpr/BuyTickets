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
            modelBuilder.Entity<Ticket>(entity => 
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(s => s.IsSelling);
            });
            
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(35);
            });
            
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Purchase");
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            
            OnModelCreatingPartial(modelBuilder);

        }

    }
}
