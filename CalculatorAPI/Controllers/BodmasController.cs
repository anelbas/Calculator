using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using CalculatorAPI.Repository;

namespace CalculatorAPI.Controllers
{
    [ApiController]
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