using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using CalculatorAPI.Repositories;


namespace CalculatorAPI.Controllers
{   
    public class TrigFunctionController
    {
          [HttpPost("TrigFunctions")]
        public async Task<IActionResult> getInputs([FromBody] TrigPostRequest trig)
        {
            
            TrigPostRequest d = new  TrigPostRequest();
            List<Trig> ls= trig.Tags;
            return new ObjectResult(TrigFunctionRepository.TrigImplement(ls));
       
        }

          
    }
}