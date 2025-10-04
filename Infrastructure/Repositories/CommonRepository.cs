using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        protected readonly TechDbContext _context;

        public CommonRepository(TechDbContext techDbContext)
        {
            _context = techDbContext;
        }

        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        public async Task UseAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
    }
}
