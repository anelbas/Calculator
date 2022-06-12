using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;


namespace CalculatorAPI.utils
{
    public class Validations
    {     
    
   string [] signs = {"+", "-", "*", "/"}; 
  string [] trigfun = {"sin", "cos", "tan"}; 

  double [] undefinedAngle= {-270,-90,90,270};
   public static void  Validate(List<Trig> ls){
          foreach (Trig obj in ls){
                if(obj.trigFunction=="sin" || obj.trigFunction=="cos" || obj.trigFunction=="tan"  ){
                   if(obj.sign=="+" || obj.sign=="-" || obj.sign=="*" || obj.sign=="/"){

                   }else{
                       throw new Exception("Please enter a valid sign");
                   }
                   
                }else{
                      throw new Exception("Please enter a valid trig function");
                }

                if(obj.trigFunction == "tan" ){
                    if(obj.degreeValue==-270 || obj.degreeValue==-90 || obj.degreeValue==90 ||obj.degreeValue==270)
                    throw new Exception("Tan is undefined for this degree value");
                }
            }   
            if(ls[0].sign=="*" || ls[0].sign=="/"){
                throw new Exception("Cannot start with division or multiplication");
            }    
            
   }
    
}
}
