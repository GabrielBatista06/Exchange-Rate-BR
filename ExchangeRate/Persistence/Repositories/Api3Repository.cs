using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeRate.Persistence.Repositories
{
    public class Api3Repository: IObtenerRemesaRepository
    {
        public async Task<decimal?> ObtenerMejorOferta(RQProcessDTO rQProcessDTO)
                {
            // Simula entrada: { exchange: { sourceCurrency, targetCurrency, quantity } }
            var input = new
            {
                exchange = new
                {
                    sourceCurrency = rQProcessDTO.SourceCurrency,
                    targetCurrency = rQProcessDTO.TargetCurrency,
                    quantity = rQProcessDTO.Amount
                }
            };

            // Simula salida: { statusCode, message, data: { total } }
            var response = new
            {
                statusCode = 200,
                message = "OK",
                data = new { total = 1.12m }
            };

            return response.data.total * input.exchange.quantity;
        }
    }
}


