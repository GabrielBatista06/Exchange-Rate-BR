using AutoMapper;
using BackEnd.Domain.IRepositories;
using ExchangeRate.DTOs;
using ExchangeRate.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IMapper _mapper;
        public LoginRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        //Lista de usuario cargada en memoria, ya que la evaluación dice: No SQL required
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, NombreUsuario = "Gbatista", Password = "3283BR2025" },
            new Usuario { Id = 2, NombreUsuario = "Banreservas", Password = "thebest123" },
            new Usuario { Id = 3, NombreUsuario = "Bendecido", Password = "passGabriel" }
        };

        //Estoy utilizando método async para simular EF (Entity Framework)
        public async Task<Usuario> ValidateUser(UsuarioDTO usuario)
        {
            foreach (var user in usuarios)
            {
                if (user.NombreUsuario == usuario.NombreUsuario && user.Password == usuario.Password)
                {
                    return user;
                    /*De la siguiente manera se utiliza el Mapper
                    return _mapper.Map<UsuarioDTO>(user);*/
                }
            }
            return null;
        }
    }
}

