using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class BoletoConfig : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> ba)
        {
            ba.ToTable("Boletos");
            ba.HasKey(x => x.Id);
            ba.Property(x => x.PayorName).IsRequired().HasMaxLength(50);
            ba.Property(x => x.PayorCPF_CNPJ).HasMaxLength(14);
            ba.Property(x => x.PayeeName).IsRequired().HasMaxLength(50);
            ba.Property(x => x.Amount).IsRequired();
            ba.Property(x => x.DueDate).IsRequired().HasMaxLength(50);
            ba.Property(x => x.Notes).HasMaxLength(50);
            ba.Property(x => x.BancoId).IsRequired().HasMaxLength(50);
        }
    }
}
