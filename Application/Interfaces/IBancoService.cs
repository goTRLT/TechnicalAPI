using Domain.DTOs;

namespace Application.Interfaces
    {
    public interface IBancoService
        {
        Task<List<BancoDto>> FindAll();
        Task<BancoDto> FindByCode(int code);
        Task<BancoDto> FindById(int id);
        Task<bool> Create(BancoDto bancoDto);
        }
    }
