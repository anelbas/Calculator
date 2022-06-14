using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;
using System.Text.RegularExpressions;
namespace CalculatorAPI.Repository
{

    public class BodmasCalculator
    {
        private Stack<string> operandStack;
        private Stack<double> variableStack;
        private bool error;
        private string message;

        public BodmasCalculator() {
            operandStack = new Stack<string>();
            variableStack = new Stack<double>();
            error = false;
            message = "";
        }

        private bool isOperand(string operand) {
            return string.Equals(operand, "+") || string.Equals(operand, "-") || string.Equals(operand, "/") || string.Equals(operand, "*");
        }

        private bool isNumber(string number) {
            return double.TryParse(number, out var n);
        }

        private string castToBiggerNumericValue(string answer) 
        {
            try
            {
                return Convert.ToInt64(answer).ToString();
            } catch {
                error = true;
                message = "Size Error: The size of the answer to the equation you entered is beyond the capacity of this calculator.";
                return "0";
            }
            

        }

        private int getPrecedence(string operand) {
            if(string.Equals(operand, "+") || string.Equals(operand, "-")) {
                return 1;
            } else if (string.Equals(operand, "/") || string.Equals(operand, "*")) {
                return 2;
            }
            return 0;
        }

        private void processOperand(string operand) {
            double input1, input2;
            if(variableStack.Count <= 0) {
                message = "Expression error.";
                error = true;
                return;
            } else {
                input2 = variableStack.Peek();
                variableStack.Pop();
            }

            if(variableStack.Count <= 0) {
                message = "Expression error. Please make sure:\n 1. You added spaces between all numbers and operands\n2. There are no double operands\n3. The equation does not start or end with an operand\n4. Decimal values are written with a dot (.) and not a comma (,).";
                error = true;
                return;
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
                answerOfEquation = input1 / input2;
            } else if (string.Equals(operand, "*")) {
                answerOfEquation = input1 * input2;
            } else {
                message = "Expression Error. Operand " + operand + " not found. Please enter p, -, / or * .";
                error = true;
            }

            variableStack.Push(answerOfEquation);

        }

        public string calculate(string equation) {
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
                        message = "Error: unbalanced paranthesis. Please ensure that each opening bracket has a closing bracket.";
                        error = true;
                    }
                }
            }

            while(operandStack.Count > 0 && isOperand(operandStack.Peek())) {
                string operandToProcess = operandStack.Peek();
                operandStack.Pop();
                processOperand(operandToProcess);
            }

            if (!error) {
                string answer = variableStack.Peek().ToString();
                variableStack.Pop();

                if(operandStack.Count > 0 || variableStack.Count > 0) {
                    message = "Expression error. Please ensure that all opeing brackets have closing brackets.";
                    error = true;
                } else if (answer.Contains('+') || Regex.IsMatch(answer, "[a-zA-Z]")) {
                    string longAnswer = castToBiggerNumericValue(answer);
                    if(error) {
                        return message;
                    }
                    return answer;
                } else {
                    return answer;
                }
                
            }
            
            return message;

        }
    }

}