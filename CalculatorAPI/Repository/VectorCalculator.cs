using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
namespace CalculatorAPI.Repository
{
    public abstract class VectorCalculator
    {

        public abstract String CalculateVectors(List<Vector> vectors);
    }
}