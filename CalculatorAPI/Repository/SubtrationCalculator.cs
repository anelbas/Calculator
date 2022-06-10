using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
namespace CalculatorAPI.Repository
{
    public class SubtrationCalculator:VectorCalculator
    {
        public override String CalculateVectors(List<Vector> vectors){
            int [] values = new int[vectors[0].values.Length];
            for(int i = 0; i< vectors[0].values.Length ;i++){
                values[i] = vectors[0].values[i]-vectors[1].values[i];
            }
            return Matrix(values);
        }
        private String Matrix(int[]matrix){
            var sb = string.Empty;
            var maxI = matrix.Length;

            {
                sb+=("{");
                for (var j = 0; j < maxI; j++)
                {
                    sb+=($"{matrix[j]}"+" ");
                }

                sb+=("}");
            }
            var result = sb.ToString();
            return result;
        }
    }
}