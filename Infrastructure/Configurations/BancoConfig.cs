using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
    {
    public class BancoConfig : IEntityTypeConfiguration<Banco>
        {
        public void Configure(EntityTypeBuilder<Banco> ba)
            {
            ba.ToTable("Bancos");
            ba.HasKey(x => x.Id);
            ba.Property(x => x.Name).IsRequired().HasMaxLength(50);
            ba.Property(x => x.Code).IsRequired();
            ba.Property(x => x.InterestPercent).IsRequired();
            ba.HasIndex(x => x.Code).IsUnique();
            }
        }
    }
