using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CalculatorAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SolveXController : Controller    
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("linear/{c:double}/{m:double}")]
        public IActionResult GetAnsL(double c,double m)
        {
            c = 0 - c;
            double ans = c / m;
            return Content("Ans: "+ans);
        }
       [Authorize]
       [HttpGet]
        [Route("linear/{a:double}/{b:double}/{c:double}")]
        public IActionResult GetAnsQ(double a, double b, double c)
        {
            double sqrtpart = b * b - 4 * a * c;

            double x, x1, x2, img;

            if (sqrtpart > 0)

            {

                x1 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);

                x2 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);
                return Content("Two real solutions: x1 " + x1+", x2"+x2);


            }
            else if (sqrtpart < 0)
            {
                sqrtpart = -sqrtpart;
                x = -b / (2 * a);
                img = System.Math.Sqrt(sqrtpart) / (2 * a);
                return Content("Two real solutions: x1 " + x + ", x2" + img);
            }
            else

            {
                x = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
                return Content("One Real Solution " + x);
            }

        }


    }
}
