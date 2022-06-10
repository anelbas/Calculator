using Microsoft.AspNetCore.Mvc;
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

       private static readonly int[] vector = new[]
        {
            1,2,3,4
        };

       public Calculator calculator = new Calculator();

        private readonly ILogger<VectorCalculatorControler> _logger;

        public VectorCalculatorControler(ILogger<VectorCalculatorControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
           
            return vector.ToArray();

        }
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