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
    public class BoletoService : IBoletoService
    {
        public Task<Boleto> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Boleto banco)
        {
            throw new NotImplementedException();
        }
    }
}
