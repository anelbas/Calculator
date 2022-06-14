using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using CalculatorAPI.Repository;
using Microsoft.AspNetCore.Authorization;


namespace CalculatorAPI.Controllers
{   
    public class TrigFunctionController
    {     [Authorize]
          [HttpPost("TrigFunctions")]
        public async Task<IActionResult> getInputs([FromBody] TrigPostRequest trig)
        {
        
            
            TrigPostRequest d = new  TrigPostRequest();
            TrigFunctionRepository trigfun = new TrigFunctionRepository();
            List<Trig> ls= trig.Tags;
            return new ObjectResult(trigfun.TrigImplement(ls));
       
        }

          
    }
}