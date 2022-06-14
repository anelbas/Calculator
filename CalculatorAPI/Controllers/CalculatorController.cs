using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        public readonly JwtAuthenticationManager jwtAuthenticationManager;

        public CalculatorController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        private static readonly string[] BODMAS = new[]
        {
        "Brackets", "Order", "Division", "Multiplication", "Addition", "Subtration"
        };
        [Authorize]
        [HttpGet(Name = "GetWeatherForecast")]

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User user)
        {
            var token = jwtAuthenticationManager.Authenticate(user.username, user.password);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}