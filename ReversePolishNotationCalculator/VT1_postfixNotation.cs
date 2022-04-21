using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postfixNotation
{
    public class Calculator
    {
        public static int Calculate(string expression)
        {
            Stack<int> stack = new();
            string[] tokens = expression.Split(' ');
            string allowed = "+-*/^";
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number)) stack.Push(number);
                else
                {
                    if (!allowed.Contains(token)) throw new ArgumentException($"Unsupported character {token}.");
                    if (stack.Count < 2) throw new ArgumentException($"Expected 2 operands, got {stack.Count}.");
                    int op2 = stack.Pop();
                    int op1 = stack.Pop();
                    if (token == "+") stack.Push(op1 + op2);
                    else if (token == "-") stack.Push(op1 - op2);
                    else if (token == "*") stack.Push(op1 * op2);
                    else if (token == "/") stack.Push(op1 / op2);
                    else if (token == "^") stack.Push((int)Math.Pow(op1, op2));
                }
            }
            if (stack.Count != 1) throw new ArgumentException("Expression doesn't evaluate to a single output. (Are you mising an operator?)");
            return stack.Pop();
        }
    }
}
