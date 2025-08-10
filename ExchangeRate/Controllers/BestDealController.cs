using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ExchangeRate.DTOs;
using ExchangeRate.Services;

namespace ExchangeRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestDealController : Controller
    {
        private readonly ObtenerMejorOfertaService _service;

        public BestDealController(ObtenerMejorOfertaService service)
        {
            _service = service;
        }


        [HttpPost("GetBestDeal")]
        public async Task<IActionResult> GetBestOffer([FromBody] RQProcessDTO request)
        {
            try
            {
                var mejorOferta = await _service.ObtenerMejorOfertaRemesa(request);

                if (mejorOferta.Formato == "XML")
                    return Content(mejorOferta.ContenidoOriginal, "application/xml");
                else
                    return Content(mejorOferta.ContenidoOriginal, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
