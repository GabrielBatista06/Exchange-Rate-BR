using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ExchangeRate.DTOs;
using ExchangeRate.Services;
using ExchangeRate.Domain.IRepositories;
using ExchangeRate.Domain.IServices;

namespace ExchangeRate.Controllers
{
    public class MejorOfertaController : Controller
    {
        private readonly ObtenerMejorOfertaService _obtenerMejorOfertaService;

        public MejorOfertaController(IEnumerable<IObtenerRemesaService> providers)
        {
            _obtenerMejorOfertaService = new ObtenerMejorOfertaService(providers);
        }

        [HttpPost("mejorOferta")]
        public async Task<IActionResult> GetBestOffer([FromBody] RQProcessDTO request)
        {
            try
            {
                var bestAmount = await _obtenerMejorOfertaService.ObtenerMejorOfertaRemesa(request);
                return Ok(new { bestAmount });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
