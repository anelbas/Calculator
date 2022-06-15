using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using CalculatorAPI.utils;
using System.Text.RegularExpressions;
using CalculatorAPI.Repository;


namespace CalculatorAPI.Repository
{
    public class TrigFunctionRepository
  
    {   
       
        public double TrigImplement( List<Trig> ls){
            Validations.Validate(ls);
            string answer = null;
            foreach (Trig obj in ls){
                if(getStr(obj.trigFunction) == "sin"){
                    answer = answer + obj.sign +  Math.Round(getNum(obj.trigFunction)* Math.Sin(obj.degreeValue*Math.PI / 180.0), 2);
                }

                if(getStr(obj.trigFunction)=="cos"){
                    answer = answer + obj.sign + Math.Round(getNum(obj.trigFunction)* Math.Cos(obj.degreeValue*Math.PI / 180.0), 2);
                }

                if(getStr(obj.trigFunction) =="tan" ){
                    answer = answer +obj.sign +Math.Round(getNum(obj.trigFunction)* Math.Tan(obj.degreeValue*Math.PI / 180.0), 2);
                }
            }        
        
            return Eval(answer.Replace(",", "."));
           

        }

    
    public static String getStr(String var){
        return Regex.Replace(var, @"\d", "");
    }
    public static Double getNum(String var){
        if(var.Any(char.IsDigit)){
            return Convert.ToDouble(Regex.Replace(var, @"\D", ""));
        }
        else {
            return 1;
        }
    }


    public static Double Eval(String expression)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        return Convert.ToDouble(table.Compute(expression, String.Empty));
    }
    }
}
