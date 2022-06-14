using System.Text.RegularExpressions;

namespace CalculatorAPI.Repository
{

    public class SimpleBodmasCalculator : BodmasBaseClass
    {
        public Stack<string> operandStack;
        public Stack<double> variableStack;
        public string answer;

        public SimpleBodmasCalculator() 
        {
            operandStack = new Stack<string>();
            variableStack = new Stack<double>();
            answer = "Null";
        }

        public override bool isOperand(string operand) 
        {
            return string.Equals(operand, "+") || string.Equals(operand, "-") || string.Equals(operand, "/") || string.Equals(operand, "*");
        }

        public override bool isNumber(string number) 
        {
            return double.TryParse(number, out var n);
        }

        public string castToBiggerNumericValue(string answer) 
        {
            try
            {
                return Convert.ToInt64(answer).ToString();
            } catch {
                throw new ErrorException(500,"Size Error: The size of the answer to the equation entered is bigger than the capacity allowed by the calculator api.");
            }
            
        }

        public override int getPrecedence(string operand) 
        {
            if(string.Equals(operand, "+") || string.Equals(operand, "-")) {
                return 1;
            } else if (string.Equals(operand, "/") || string.Equals(operand, "*")) {
                return 2;
            }
            return 0;
        }

        public override void processOperand(string operand) 
        {
            double input1, input2;
            if(variableStack.Count <= 0) {
                throw new ErrorException(500,"Expression error. Please start your equation with a numeric value and not an operand.");
            } else {
                input2 = variableStack.Peek();
                variableStack.Pop();
            }

            if(variableStack.Count <= 0) {
                throw new ErrorException(500,"Expression error. Please make sure:\n1. You added spaces between all numbers and operands\n2. There are no double operands\n3. The equation does not start or end with an operand\n4. Decimal values are written with a dot (.) and not a comma (,).");
            } else {
                input1 = variableStack.Peek();
                variableStack.Pop();
            }

            double answerOfEquation = 0;

                if(string.Equals(operand, "+")) {
                answerOfEquation = input1 + input2;
            } else if (string.Equals(operand, "-")) {
                answerOfEquation = input1 - input2;
            } else if (string.Equals(operand, "/")) {
                if (input2 == 0) {
                    throw new ErrorException(500,"Division Error: You cannot divide by zero.");
                } else {
                    answerOfEquation = input1 / input2;
                }
            } else if (string.Equals(operand, "*")) {
                answerOfEquation = input1 * input2;
            } else {
                throw new ErrorException(500,"Expression Error. Operand " + operand + " not found. Please enter p, -, / or * .");
            }

            variableStack.Push(answerOfEquation);

        }

        public override string calculate(string equation) 
        {
            string[] individualInputs = equation.Split(" ");

            foreach (string input in individualInputs) {
                if(isNumber(input)) {
                    variableStack.Push(double.Parse(input));
                } else if (isOperand(input)) {
                    if(operandStack.Count == 0 || getPrecedence(input) > getPrecedence(operandStack.Peek())) {
                        operandStack.Push(input);
                    } else {
                        while (operandStack.Count != 0 && getPrecedence(input) <= getPrecedence(operandStack.Peek())) {
                            string operandToProcess = operandStack.Peek();
                            operandStack.Pop();
                            processOperand(operandToProcess);
                        }
                        operandStack.Push(input);
                    }
                } else if (string.Equals(input, "(")) {
                    operandStack.Push(input);
                } else if (string.Equals(input, ")")) {
                    while(operandStack.Count > 0 && isOperand(operandStack.Peek())) {
                        string operandToProcess = operandStack.Peek();
                        operandStack.Pop();
                        processOperand(operandToProcess);
                    }

                if (operandStack.Count > 0 && string.Equals(operandStack.Peek(), "(")) {
                    operandStack.Pop();
                    } else {
                        throw new ErrorException(500,"Error: unbalanced paranthesis. Please ensure that each opening bracket has a closing bracket and that there are spaces between all individual input tokens.");
                    }
                }
            }

            while(operandStack.Count > 0 && isOperand(operandStack.Peek())) 
            {
                string operandToProcess = operandStack.Peek();
                operandStack.Pop();
                processOperand(operandToProcess);
            }

            answer = variableStack.Peek().ToString();
            variableStack.Pop();

            if(operandStack.Count > 0 || variableStack.Count > 0) {
                throw new ErrorException(500,"Expression error. Please ensure that all opeing brackets have closing brackets.");
            } else if (answer.Contains('+') || Regex.IsMatch(answer, "[a-zA-Z]")) {
                string longAnswer = castToBiggerNumericValue(answer);
                return longAnswer;
            }  
            
            return answer;

        }
    }

}