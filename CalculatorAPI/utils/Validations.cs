using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using CalculatorAPI.Repository;
using System.Text.RegularExpressions;



namespace CalculatorAPI.utils
{
    public class Validations
    {     

   public static void  Validate(List<Trig> ls){
        foreach (Trig obj in ls){
            if( Regex.Replace(obj.trigFunction, @"\d", "") == "sin" || Regex.Replace(obj.trigFunction, @"\d", "") == "cos" || Regex.Replace(obj.trigFunction, @"\d", "") == "tan"  ){
                if(obj.sign == "+" || obj.sign == "-" || obj.sign == "*" || obj.sign == "/"){

                }else{
                    throw new ErrorException(500,"Please enter a valid sign");
                }
                   
            }else{
                throw new ErrorException(500, "Please enter a defined trig function choose between cos, sin & tan");
            }

            if(Regex.Replace(obj.trigFunction, @"\d", "") == "tan" ){
                if(obj.degreeValue ==-270 || obj.degreeValue ==-90 || obj.degreeValue ==90 ||obj.degreeValue == 270)
                throw new ErrorException(500,"Tan is undefined for this degree value");
            }
        }   
            if(ls[0].sign == "*" || ls[0].sign == "/"){
                throw new ErrorException(500, "Cannot start with division or multiplication");
        }    
            
   }        
    
}
}
