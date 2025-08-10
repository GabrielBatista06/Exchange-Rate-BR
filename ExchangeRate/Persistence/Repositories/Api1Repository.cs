using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using ExchangeRate.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeRate.Persistence.Repositories
{
    public class Api1Repository: IObtenerRemesaRepository
    {
        //Estoy utilizando método async para simular EF (Entity Framework)
        public async Task<RSProcessDTO> ObtenerMejorOferta(RQProcessDTO request)
        {
            ExchangeRateRandom exchangeRateRandom = new ExchangeRateRandom();
            var valor = exchangeRateRandom.GenerarNumeroRandom();

            var input = new { from = request.SourceCurrency, to = request.TargetCurrency, value = request.Amount };
            var response = new { rate = valor * request.Amount};

            return new RSProcessDTO
            {
                Amount = response.rate * request.Amount,
                ContenidoOriginal = JsonSerializer.Serialize(response),
                Formato = "JSON"
            };

        }
    }
}
