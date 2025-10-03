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
    public class BancoConfig : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> ba)
        {
            ba.ToTable("Bancos");
            ba.HasKey(x => x.Id);
            ba.Property(x => x.Name).IsRequired().HasMaxLength(50);
            ba.Property(x => x.Code).IsRequired();
            ba.Property(x => x.InterestPercent).IsRequired();
        }
    }
}
