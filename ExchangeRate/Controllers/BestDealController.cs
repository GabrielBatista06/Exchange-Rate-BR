using ExchangeRate.DTOs;
using ExchangeRate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
       // [Authorize]
       //Si deseas probar el login descomenta la parte de arriba y vuelve a lanzar el proyecto
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
