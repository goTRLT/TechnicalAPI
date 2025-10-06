using Domain.DTOs;

namespace Application.Interfaces
    {
    public interface IBoletoService
        {
        Task<BoletoDto> Find(int id);
        Task<bool> Create(BoletoDto bancoDto);
        Task<BoletoDto?> FindPayorDocs(string? cpfCnpj, string payorName);
        }
    }
