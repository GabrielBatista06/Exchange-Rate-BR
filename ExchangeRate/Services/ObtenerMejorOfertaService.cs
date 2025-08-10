using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ExchangeRate.Domain.IServices;
using ExchangeRate.DTOs;
using System.Linq;

namespace ExchangeRate.Services
{
    public class ObtenerMejorOfertaService
    {
        private readonly IEnumerable<IObtenerRemesaService> _remesaServices;

        public ObtenerMejorOfertaService(IEnumerable<IObtenerRemesaService> remesaServices)
        {
            _remesaServices = remesaServices;
        }

        public async Task<decimal> ObtenerMejorOfertaRemesa (RQProcessDTO request)
        {
            var tasks = _remesaServices.Select(p => p.ObtenerMejorOferta(request));
            var results = await Task.WhenAll(tasks);

            return results.Where(r => r.HasValue).Max() ?? throw new Exception("No valid exchange rates found.");
        }
    }
}
