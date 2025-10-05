using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Banco?> Find(int code)
        {
            var banco = await Get(code);

            return banco is null ? banco : new();
        }
        public async Task<bool> Create(Banco banco)
        {
            await UseAsync(banco);

            var records = _context.SaveChanges();

            return records > 0;
        }
    }
}
