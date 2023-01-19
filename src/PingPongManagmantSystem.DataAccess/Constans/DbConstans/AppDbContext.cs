using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.Domain;
using PingPongManagmantSystem.Domain.Entities;
using System.Collections.Generic;

namespace PingPongManagmantSystem.Domain.Constans.DbConstans
{
    public class AppDbContext : DbContext
    {
        public DbSet<BarProduct> BarProducts { get; set; } = default!;
        public DbSet<Card> Cards { get; set; } = default!;
        public DbSet<Cassa> Cassas { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<PingPongTable> PingPongTables { get; set; } = default!;
        public DbSet<SportProduct> SportProducts { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\A S U S\Desktop\PingPongManagmantSystem\database\database.db");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
