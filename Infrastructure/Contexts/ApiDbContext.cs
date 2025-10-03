using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Banco> Bancos => Set<Banco>();
        public DbSet<Boleto> Boletos => Set<Boleto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.HasDefaultSchema("TechnicalDb");
        }
    }
}