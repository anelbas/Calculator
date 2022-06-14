using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
namespace CalculatorAPI.Repository
{
    public class Calculator
    {
        private List<Vector> vectors = new List<Vector>();
        public VectorCalculator vectorCalculator; 
        public void setOpperand(VectorCalculator vectorCalculator){
            this.vectorCalculator = vectorCalculator;
        }
        public void addVectors(Vector vector){
         try
            {
                if (vectors.Count>2)
                {
                    throw new Exception("You can't insert more than 2 Vectors !!!!!");
                }
                vectors.Add(vector);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
        }
        public String Calcutulate(){
            return vectorCalculator.CalculateVectors(vectors);
        }
    }
}