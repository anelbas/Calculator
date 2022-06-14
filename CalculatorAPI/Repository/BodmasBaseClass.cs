using System.Text.RegularExpressions;

namespace CalculatorAPI.Repository
{
    public abstract class BodmasBaseClass
    {
        public abstract bool isOperand(string operand);

        public abstract bool isNumber(string number);

        public abstract int getPrecedence(string operand);

        public abstract void processOperand(string operand);

        public abstract string calculate(string equation);


    }

}