using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
namespace CalculatorAPI.Repository
{
    public class MultiplicationCalculator:VectorCalculator
    {
        public override String CalculateVectors(List<Vector> vectors){
            int [][] values = new int[vectors[0].values.Length][] ;
            for(int i = 0; i< vectors[0].values.Length ;i++){
                values[i]= new int[vectors[1].values.Length];
                for (int j = 0 ;j<vectors[1].values.Length;j++){
                    values[i][j]=vectors[0].values[i]*vectors[1].values[j];
                }
            }
            
            return Matrix(values);
        }
        private String Matrix(int[][]matrix){
            var sb = string.Empty;
            var maxI = matrix.Length;
            var maxJ = matrix[0].Length;
            for (var i = 0; i < maxI; i++)
            {
                sb+=("{");
                for (var j = 0; j < maxJ; j++)
                {
                    sb+=($"{matrix[i][j]}"+" ");
                }

                sb+=("}"+"\n");
            }

            var result = sb.ToString();
            return result;
        }
    }
}