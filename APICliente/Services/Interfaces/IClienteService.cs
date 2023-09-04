using APICliente.Models;
using APICliente.Models.DTO;

namespace APICliente.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente?> GetClienteById(int id);
        void CreateCliente(ClienteDTO clienteDTO);
        void UpdateCliente(ClienteDTO clienteDTO);
        void DeleteCliente(int id);
    }
}
