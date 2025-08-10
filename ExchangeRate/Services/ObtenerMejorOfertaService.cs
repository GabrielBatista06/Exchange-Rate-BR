using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRate.Services
{
    public class ObtenerMejorOfertaService
    {
        private readonly IEnumerable<IObtenerRemesaRepository> _remesaServices;

        public ObtenerMejorOfertaService(IEnumerable<IObtenerRemesaRepository> remesaServices)
        {
            _remesaServices = remesaServices;
        }

        public async Task<RSProcessDTO> ObtenerMejorOfertaRemesa(RQProcessDTO request)
        {
            var tasks = _remesaServices.Select(p => p.ObtenerMejorOferta(request));
            var results = await Task.WhenAll(tasks);

            var mejorOferta = results.OrderByDescending(r => r.Amount).FirstOrDefault();
            if (mejorOferta == null)
                throw new Exception("Ooops!! No se encontraron ofertas");

            return mejorOferta;
        }
    }
}
