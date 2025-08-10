using ExchangeRate.DTOs;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.IServices
{
    public interface IObtenerRemesaService
    {
        Task<decimal?> ObtenerMejorOferta(RQProcessDTO rQProcessDTO);
    }
}
