using APICliente.Models;
using APICliente.Models.DTO;
using AutoMapper;

namespace APICliente.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDTO>(); 
            CreateMap<ClienteDTO, Cliente>(); 
        }
    }
}
