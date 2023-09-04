using APICliente.Models;
using APICliente.Models.DTO;

namespace APICliente.Repositories.Interfaces
{
    public interface ILogradouroRepository
    {
        Task<IEnumerable<Logradouro>> GetAllAsync();
        Task <Logradouro?> GetByIdAsync(int id);
        void Create(Logradouro logradouro);
        void Update(Logradouro logradouro);
        void Delete(int id);
    }
}
