using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IBancoRepository
    {
        Task<List<Banco>> FindAll();
        Task<Banco> FindByCode(int code);
        Task<Banco> FindById(int id);
        Task<bool> Create(Banco banco);
    }
}
