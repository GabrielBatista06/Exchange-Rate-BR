using ExchangeRate.DTOs;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.IRepositories
{
    public interface IObtenerRemesaRepository
    {
        Task<decimal?> ObtenerMejorOferta(RQProcessDTO rQProcessDTO);

    }
}
