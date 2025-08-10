using ExchangeRate.DTOs;
using ExchangeRate.Persistence.Models;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface ILoginRepository
    {

        Task<Usuario> ValidateUser(UsuarioDTO usuarioDto);
    }
}
