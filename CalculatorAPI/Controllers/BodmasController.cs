using Microsoft.AspNetCore.Mvc;
using CalculatorAPI.Repository;
using Microsoft.AspNetCore.Authorization;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]

    public class BodmasController : ControllerBase{

        private readonly ILogger<CalculatorController> _logger;

        public BodmasController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        BodmasCalculator calculator = new BodmasCalculator();

        [HttpPost(Name = "Bodmas")]
        public string getBodmasAnswer([FromBody] string equation) 
        {
            return calculator.calculate(equation);
        }

    }

}