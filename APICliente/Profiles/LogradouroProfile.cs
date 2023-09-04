using APICliente.Models;
using APICliente.Models.DTO;
using AutoMapper;

namespace APICliente.Profiles
{
    public class LogradouroProfile : Profile
    {
        public LogradouroProfile()
        {
            CreateMap<Logradouro, LogradouroDTO>();
            CreateMap<LogradouroDTO, Logradouro>();
        }
    }
}