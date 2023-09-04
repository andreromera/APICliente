using AutoMapper;
using APICliente.Models;
using APICliente.Models.DTO;
using APICliente.Repositories.Interfaces;
using APICliente.Services.Interfaces;

namespace APICliente.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task <IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task <Cliente?> GetClienteById(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        } 

        public void CreateCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Create(cliente);
        }

        public void UpdateCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Update(cliente);
        }

        public void DeleteCliente(int id)
        {
            _clienteRepository.Delete(id);
        }
    }
}
