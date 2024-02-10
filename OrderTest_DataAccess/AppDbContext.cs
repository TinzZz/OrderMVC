using Microsoft.EntityFrameworkCore;
using OrderTest_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest_DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.PickUpDate)
                .HasColumnType("DATE");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)            // Dont need with Web App. Using with Console App.
        //{
        //    options.UseSqlServer("Server=THROTTLEMACHINE;DataBase=OrderTest;TrustServerCertificate=True;Trusted_Connection=True;");
        //}
    }
}
