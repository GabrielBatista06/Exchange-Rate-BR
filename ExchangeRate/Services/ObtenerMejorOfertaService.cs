using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRate.Services
{
    public class ObtenerMejorOfertaService
    {
        private readonly IEnumerable<IObtenerRemesaRepository> _remesaServices;
        private readonly ILogger<ObtenerMejorOfertaService> _logger;

        public ObtenerMejorOfertaService(IEnumerable<IObtenerRemesaRepository> remesaServices,
                                                                ILogger<ObtenerMejorOfertaService> logger)
        {
            _remesaServices = remesaServices;
            _logger = logger;
        }

        public async Task<RSProcessDTO> ObtenerMejorOfertaRemesa(RQProcessDTO request)
        {
            _logger.LogInformation("Inicio de método ObtenerMejorOfertaRemesa");

            try
            {
                var tasks = _remesaServices.Select(p => p.ObtenerMejorOferta(request));
                var results = await Task.WhenAll(tasks);

                var mejorOferta = results.OrderByDescending(r => r.Amount).FirstOrDefault();
                if (mejorOferta == null)
                {
                    _logger.LogWarning("No se encontraron tasas válidas para la solicitud.");
                    throw new Exception("Ooops!! No se encontraron ofertas");
                }
                _logger.LogInformation("Mejor tasa encontrada: ", mejorOferta.Amount);
                 return mejorOferta;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error en ObtenerMejorOfertaRemesa");
                throw;
            }

          
        }
    }
}
