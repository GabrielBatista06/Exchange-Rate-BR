using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeRate.Persistence.Repositories
{
    public class Api1Repository: IObtenerRemesaRepository
    {

        public async Task<decimal?> ObtenerMejorOferta(RQProcessDTO request)
        {
            // Simula entrada: { from, to, value }
            var input = new { from = request.SourceCurrency, to = request.TargetCurrency, value = request.Amount };

            // Simula salida: { rate }
            var response = new { rate = 1.10m };

            return response.rate * input.value;

        }
    }
}
