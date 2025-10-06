using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BancoRepository : CommonRepository<Banco>, IBancoRepository
    {
        public BancoRepository(TechDbContext techDbContext) : base(techDbContext) { }

        public async Task<List<Banco>> FindAll()
        {
            var bancos = await GetAll();

            return bancos.ToList();
        }

        public async Task<Banco?> FindByCode(int code)
        {
            return await _context.Bancos.FirstOrDefaultAsync(b => b.Code == code);
        }
        public async Task<bool> Create(Banco banco)
        {
            await UseAsync(banco);

            var records = _context.SaveChanges();

            return records > 0;
        }

        public async Task<Banco> FindById(int id)
        {
            return await _context.Bancos.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
