using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IBoletoRepository
    {
        Task<Boleto> Find(int id);
        Task<bool> Create(Boleto banco);
    }
}
