using AutoMapper;
using APICliente.Models;
using APICliente.Models.DTO;
using APICliente.Repositories.Interfaces;
using APICliente.Services.Interfaces;

namespace APICliente.Services
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;
        private readonly IMapper _mapper;

        public LogradouroService(ILogradouroRepository logradouroRepository, IMapper mapper)
        {
            _logradouroRepository = logradouroRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Logradouro>> GetAllLogradourosAsync()
        {
            return await _logradouroRepository.GetAllAsync();
        }

        public async Task<Logradouro?> GetLogradouroByIdAsync(int id)
        {
            return await _logradouroRepository.GetByIdAsync(id);
        }

        public void CreateLogradouro(LogradouroDTO logradouroDTO) 
        {
            Logradouro logradouro = _mapper.Map<Logradouro>(logradouroDTO);
            _logradouroRepository.Create(logradouro);
        }

        public void UpdateLogradouro(LogradouroDTO logradouroDTO)
        {
            Logradouro logradouro = _mapper.Map<Logradouro>(logradouroDTO);
            _logradouroRepository.Update(logradouro);
        }

        public void DeleteLogradouro(int id)
        {
            _logradouroRepository.Delete(id);
        }
    }
}
