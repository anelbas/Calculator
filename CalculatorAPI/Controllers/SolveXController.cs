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
       [AllowAnonymous]
       [HttpGet]
        [Route("quadratic/{a:double}/{b:double}/{c:double}")]
        public IActionResult GetAnsQ(double a, double b, double c)
        {
            double sqrtpart = b * b - 4 * a * c;

            double x, x1, x2, img;

            if (sqrtpart > 0)

            {

                x1 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);

                x2 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);
                return Content("Two real solutions: x1 " + x1+", x2 "+x2);


            }
            else if (sqrtpart < 0)
            {
                sqrtpart = -sqrtpart;
                x = -b / (2 * a);
                img = System.Math.Sqrt(sqrtpart) / (2 * a);
                return Content("Two real solutions: x1 " + x + ", x2 " + img);
            }
            else

            {
                x = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
                return Content("One Real Solution " + x);
            }

        }

        [HttpGet]
        [Route("cubic/{a:double}/{b:double}/{c:double}/{d:double}")]
        public IActionResult cubicsolve(double a, double b, double c, double d)
        {

            if (a == 0)
            {
                return Content("The coefficient of the cube of x is 0. Please use the utility for a SECOND degree quadratic. No further action taken.");
                
            } //End if a == 0

            if (d == 0)
            {
                return Content("One root is 0. Now divide through by x and use the utility for a SECOND degree quadratic to solve the resulting equation for the other two roots. No further action taken.");

            } //End if d == 0
            b /= a;
            c /= a;
            d /= a;
            double disc, q, r, dum1, s, t, term1, r13;
            q = (3.0 * c - (b * b)) / 9.0;
            r = -(27.0 * d) + b * (9.0 * c - 2.0 * (b * b));
            r /= 54.0;
            disc = q * q * q + r * r;
            double x1I = 0; //The first root is always real.
            term1 = (b / 3.0);
            if (disc > 0)
            { // one root real, two are complex
                s = r + System.Math.Sqrt(disc);
                s = ((s < 0) ? -System.Math.Pow(-s, (1.0 / 3.0)) : System.Math.Pow(s, (1.0 / 3.0)));
                t = r - System.Math.Sqrt(disc);
                t = ((t < 0) ? -System.Math.Pow(-t, (1.0 / 3.0)) : System.Math.Pow(t, (1.0 / 3.0)));
                double x1R = -term1 + s + t;
                term1 += (s + t) / 2.0;
                double x3R = -term1;
                double x2R = -term1;
                term1 = System.Math.Sqrt(3.0) * (-t + s) / 2;
                double x2I = term1;
                double x3I = -term1;
                return Content("x1R: "+x1R+ "\n\nx2R: "+x2R + "\nx2I: " + x2I + "\n\nx3R: " + x3R+ "\nx3I: "+x3I) ;
            }
            // End if (disc > 0)
            // The remaining options are all real
            double x3Im = 0;
            double x2Im= 0;
            if (disc == 0)
            { // All roots real, at least two are equal.
                double hi=0;
                r13 = ((r < 0) ? -System.Math.Pow(-r, (1.0 / 3.0)) : System.Math.Pow(r, (1.0 / 3.0)));
                double x1R = -term1 + 2.0 * r13;
                double x3R = -(r13 + term1);
                double x2R = -(r13 + term1);
                return Content("x1R: " + x1R + "\nx2R: " + x2R + "\n\nx3R: " + x3R);
            } // End if (disc == 0)
              // Only option left is that all roots are real and unequal (to get here, q < 0)
            q = -q;
            dum1 = q * q * q;
            dum1 = System.Math.Acos(r / System.Math.Sqrt(dum1));
            r13 = 2.0 * System.Math.Sqrt(q);
            double x1Re = -term1 + r13 * System.Math.Cos(dum1 / 3.0);
            double x2Re = -term1 + r13 * System.Math.Cos((dum1 + 2.0 * System.Math.PI) / 3.0);
            double x3Re = -term1 + r13 * System.Math.Cos((dum1 + 4.0 * System.Math.PI) / 3.0);
            return Content("x1R: " + x1Re + "\nx2R: " + x2Re + "\n\nx3R: " + x3Re);
        }  //End of cubicSolve


    }
}
