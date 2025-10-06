using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
    {
    public class TechDbContext : DbContext
        {
        public TechDbContext(DbContextOptions<TechDbContext> options) : base(options)
            {
            }

        public DbSet<Banco> Bancos => Set<Banco>();
        public DbSet<Boleto> Boletos => Set<Boleto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.HasDefaultSchema("TechDb");
            }
        }
    }