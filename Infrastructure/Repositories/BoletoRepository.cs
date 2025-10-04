using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BoletoRepository : CommonRepository<Boleto>, IBoletoRepository
    {
        public BoletoRepository(TechDbContext techDbContext) : base(techDbContext) { }

        public async Task<Boleto?> Find(int id)
        {
            var boleto = await Find(id);

            return boleto is null ? boleto : new();
        }
        public async Task<bool> Create(Boleto boleto)
        {
            await UseAsync(boleto);

            var records = _context.SaveChanges();

            return records > 1;
        }
    }
}
