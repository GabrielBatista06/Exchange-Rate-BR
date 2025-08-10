using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using ExchangeRate.DTOs;
using ExchangeRate.Persistence.Models;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(UsuarioDTO usuario)
        {
            return await _loginRepository.ValidateUser(usuario);

        }
    }
}
