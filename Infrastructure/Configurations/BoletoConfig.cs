using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
    {
    public class BoletoConfig : IEntityTypeConfiguration<Boleto>
        {
        public void Configure(EntityTypeBuilder<Boleto> bo)
            {
            bo.ToTable("Boletos");
            bo.HasKey(x => x.Id);
            bo.Property(x => x.PayorName).IsRequired().HasMaxLength(50);
            bo.Property(x => x.PayorCpfCnpj).HasMaxLength(14);
            bo.Property(x => x.PayeeName).IsRequired().HasMaxLength(50);
            bo.Property(x => x.Amount).IsRequired();
            bo.Property(x => x.DueDate).IsRequired().HasMaxLength(50);
            bo.Property(x => x.Notes).HasMaxLength(50);
            bo.Property(x => x.BancoId).IsRequired().HasMaxLength(50);
            }
        }
    }
