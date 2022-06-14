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
    public class TrigFunctionController:ControllerBase
    {     [Authorize]
          [HttpPost("TrigFunctions")]
        public IActionResult getInputs([FromBody] TrigPostRequest trig)
        {
        
            try{
                TrigPostRequest d = new  TrigPostRequest();
                TrigFunctionRepository trigfun = new TrigFunctionRepository();
                List<Trig> ls= trig.Tags;
                return new ObjectResult(trigfun.TrigImplement(ls));
            }
            catch(ErrorException ex){
                Response.StatusCode = ex.StatusCode;
                return new ObjectResult(ex.ToString());

            }
            
    

          
    }
}
}