using AutoMapper;
using ExchangeRate.DTOs;
using ExchangeRate.Persistence.Models;

namespace ExchangeRate.ProfileAutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
