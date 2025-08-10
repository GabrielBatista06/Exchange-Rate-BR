using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using ExchangeRate.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeRate.Persistence.Repositories
{
    public class Api3Repository: IObtenerRemesaRepository
    {
        //Estoy utilizando método async para simular EF (Entity Framework)
        public async Task<RSProcessDTO> ObtenerMejorOferta(RQProcessDTO rQProcessDTO)
        {
            ExchangeRateRandom exchangeRateRandom = new ExchangeRateRandom();
            var valor = exchangeRateRandom.GenerarNumeroRandom();

            var input = new
            {
                exchange = new
                {
                    sourceCurrency = rQProcessDTO.SourceCurrency,
                    targetCurrency = rQProcessDTO.TargetCurrency,
                    quantity = rQProcessDTO.Amount
                }
            };

            var response = new
            {
                statusCode = 200,
                message = "OK",
                data = new { total = valor * rQProcessDTO.Amount }
            };

            return new RSProcessDTO
            {
                Amount = response.data.total * input.exchange.quantity,
                ContenidoOriginal = JsonSerializer.Serialize(response),
                Formato = "JSON"
            };
        }
    }
}


