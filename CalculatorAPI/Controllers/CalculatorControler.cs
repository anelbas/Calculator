using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorControler : ControllerBase
    {
        private static readonly string[] BODMAS = new[]
        {
            "Brackets", "Order", "Division", "Multiplication", "Addition", "Subtraction"
        };

        private readonly ILogger<CalculatorControler> _logger;

        public CalculatorControler(ILogger<CalculatorControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<String> Get()
        {

            return BODMAS.ToArray();
        }
    }
}
