using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using CalculatorAPI.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VectorCalculatorControler : ControllerBase
    {
       public Calculator calculator = new Calculator();

        private readonly ILogger<VectorCalculatorControler> _logger;

        public VectorCalculatorControler(ILogger<VectorCalculatorControler> logger)
        {
            _logger = logger;
        }
        [Authorize]
        [Route("Addition")]
        [HttpPost]
        public String Addition([FromBody] Vectors vectors)
        {
            calculator.setOpperand(new AdditionCalculator());
            calculator.addVectors(vectors.vector1);
            calculator.addVectors(vectors.vector2);
            String result = calculator.Calcutulate();
            return result;
        }
        [Authorize]
        [Route("Subtract")]
        [HttpPost]
        public String Subtract([FromBody] Vectors vectors)
        {
            calculator.setOpperand(new SubtrationCalculator());
            calculator.addVectors(vectors.vector1);
            calculator.addVectors(vectors.vector2);
            String result = calculator.Calcutulate();
            return result;
        }
        [Authorize]
        [Route("Multiply")]
        [HttpPost]
        public String Multiply([FromBody] Vectors vectors)
        {
            calculator.setOpperand(new MultiplicationCalculator());
            calculator.addVectors(vectors.vector1);
            calculator.addVectors(vectors.vector2);
            String result = calculator.Calcutulate();
            return result;
        }
    }
}