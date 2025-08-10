using ExchangeRate.DTOs;
using ExchangeRate.Persistence.Models;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
 public interface ILoginService
    {
        Task<Usuario> ValidateUser(UsuarioDTO usuarioDto);
    }
}
