using APICliente.Models;

namespace APICliente.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task <Cliente?> GetByIdAsync(int id);
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
