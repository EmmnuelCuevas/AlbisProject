using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class AppDbContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                var connetionString = System.Configuration.ConfigurationManager.AppSettings["DefaultConnection"];
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=MediExpress;User Id=postgres;Password=Axcom1;");
            }
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set;  }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<NCF> NCFs { get; set; }
    }
}
