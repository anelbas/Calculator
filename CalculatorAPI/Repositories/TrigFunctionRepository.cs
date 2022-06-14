using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using CalculatorAPI.utils;
using System.Text.RegularExpressions;


namespace CalculatorAPI.Repositories
{
    public class TrigFunctionRepository
    {       
        public static double TrigImplement( List<Trig> ls){
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

            // eval will be replaced by that method that evaluates bodmas
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

    //this method will need to be deleted when the bodmas implementation is working
    public static Double Eval(String expression)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        return Convert.ToDouble(table.Compute(expression, String.Empty));
    }
    }
}