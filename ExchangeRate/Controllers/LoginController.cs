using BackEnd.Domain.IServices;
using ExchangeRate.DTOs;
using ExchangeRate.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        //Método para iniciar sesión 
        //Utilizo DTOs para no comprometer el modelo de la DB
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuario)
        {
            try
            {
  
                var user =await _loginService.ValidateUser(usuario);

                if (user == null)
                {
                    return BadRequest(new { message = "Usuario o contraseña incorrectos" });

                }
                string tokenString = JwtConfigurator.GetToken(user, _configuration);
                return Ok(new { token = tokenString});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
