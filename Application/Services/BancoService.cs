using Application.Interfaces;
using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BancoService : IBancoService
    {
        public Task<List<Banco>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Banco> Find(int code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Banco banco)
        {
            throw new NotImplementedException();
        }
    }
}