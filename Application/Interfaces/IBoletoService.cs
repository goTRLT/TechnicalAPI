using Domain.DTOs;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBoletoService
    {
        Task<BoletoDto> Find(int id);
        Task<bool> Create(BoletoDto bancoDto);
    }
}
