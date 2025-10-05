using Domain.DTOs;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBancoService
    {
        Task<List<BancoDto>> FindAll();
        Task<BancoDto> Find(int code);
        Task<bool> Create(BancoDto bancoDto);
    }
}
