using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
namespace CalculatorAPI.Repository
{
    public class AdditionCalculator:VectorCalculator
    {
        public override String CalculateVectors(List<Vector> vectors){
            int [] values = new int[vectors[0].values[0].Length];
            
            if (vectors[0].values[0].Length == vectors[1].values[0].Length && vectors[1].values[0].Length>1){
                values=HorizontalDimension(vectors);
            }
            else if (vectors[0].values.Length == vectors[1].values.Length && vectors[1].values.Length > 1){
                values = VerticalDimension(vectors);
            }
            else {
                throw new ErrorException(400,"Incorrect Dimensions, To add matrices, the matrices must have the same dimensions");
            }
            
            return Matrix(values);
            
        }
        private int [] HorizontalDimension(List<Vector> vectors){
            int [] values = new int[vectors[0].values[0].Length];
            for(int i = 0; i< vectors[0].values[0].Length ;i++){
                    values[i] = vectors[0].values[0][i]+vectors[1].values[0][i];
                }
            return values;
        }
        private int [] VerticalDimension(List<Vector> vectors){
            int [] values = new int[vectors[0].values.Length];
            for(int i = 0; i< vectors[0].values.Length ;i++){
                    values[i] = vectors[0].values[i][0]+vectors[1].values[i][0];
                }
            return values;
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

                sb+=("}"+"\n");
            }
            var result = sb.ToString();
            return result;
        }
    }
}
