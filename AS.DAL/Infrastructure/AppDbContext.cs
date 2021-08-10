using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS.DAL.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Products { get; set; }
        public DbSet<Invoice> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Grade
            modelBuilder.Entity<Customer>().ToTable("Customer");

            //RelationShips
            modelBuilder.Entity<Customer>()
                   .HasMany<Invoice>(g => g.Invoices)
                   .WithOne(app => app.customer)
                   .HasForeignKey(app => app.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Invoice
            modelBuilder.Entity<Invoice>().ToTable("Invoices");

            //Invoce link
            modelBuilder.Entity<Invoice>()
                 .HasOne<Customer>(app => app.customer)
                 .WithMany(ap => ap.Invoices)
                 .HasForeignKey(app => app.CustomerId)
                 .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
