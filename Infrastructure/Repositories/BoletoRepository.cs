using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
    {
    public class BoletoRepository : CommonRepository<Boleto>, IBoletoRepository
        {
        public BoletoRepository(TechDbContext techDbContext) : base(techDbContext) { }

        public async Task<Boleto?> Find(int id)
            {
            Boleto boleto = new Boleto();
            boleto = await Get(id);
            return boleto is null ? new() : boleto;
            }

        public async Task<bool> Create(Boleto boleto)
            {
            await UseAsync(boleto);

            var records = _context.SaveChanges();

            return records > 0;
            }

        public async Task<Boleto?> FindPayorDocs(string? cpfCnpj, string payorName)
            {
            return await _context.Boletos
                .FirstOrDefaultAsync(b => b.PayorCpfCnpj == cpfCnpj || b.PayorName == payorName);
            }
        }
    }
