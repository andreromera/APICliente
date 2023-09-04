using APICliente.Models;
using APICliente.Models.DTO;

namespace APICliente.Services.Interfaces
{
    public interface ILogradouroService
    {
        Task<IEnumerable<Logradouro>> GetAllLogradourosAsync();
        Task<Logradouro?> GetLogradouroByIdAsync(int id);
        void CreateLogradouro(LogradouroDTO logradouroDTO);
        void UpdateLogradouro(LogradouroDTO logradouroDTO);
        void DeleteLogradouro(int id);
    }
}
