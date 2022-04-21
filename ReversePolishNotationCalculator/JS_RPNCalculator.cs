using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public static class RPNCalculator
    {
        private static int _factorial(int n)
        {
            if (n > 1)
            {
                return n * _factorial(n - 1);
            }
            return 1;
        }

        public static int FromString(string input)
        {
            var words = input.Split(' ');

            var arr = new List<Element>();

            foreach (var w in words)
            {
                if (w != "") arr.Add(new Element(w));
            }

            bool wasChanged;

            while (arr.Count > 1)
            {
                wasChanged = false;
                for (int i = 0; i < arr.Count - 1; i++)
                {
                    if (arr[i].isNum && (arr[i+1].Type == elementType.Factorial))
                    {
                        var newEl = new Element(_factorial(arr[i].value));
                        arr.RemoveRange(i, 2);
                        arr.Insert(i, newEl);
                        wasChanged = true;
                    }

                    if (i < arr.Count - 2 && arr[i].isNum && arr[i + 1].isNum && !arr[i + 2].isNum)
                    {
                        int newNum = 0;
                        switch (arr[i + 2].Type)
                        {
                            case elementType.Multiply: newNum = arr[i].value * arr[i + 1].value; break;
                            case elementType.Divide: newNum = arr[i].value / arr[i + 1].value; break;
                            case elementType.Add: newNum = arr[i].value + arr[i + 1].value; break;
                            case elementType.Subtract: newNum = arr[i].value - arr[i + 1].value; break;
                            case elementType.Modulo: newNum = arr[i].value % arr[i + 1].value; break;
                            default: break;
                        }
                        var newEl = new Element(newNum);
                        arr.RemoveRange(i, 3);
                        arr.Insert(i, newEl);
                        wasChanged = true;
                    }
                }

                if (!wasChanged)
                {
                    throw new ArgumentException("Invalid input: " + input);
                }
            }

            return arr[0].value;
        }
    }

    public enum elementType
    {
        Number, Multiply, Divide, Add, Subtract, Modulo, Factorial
    }

    public class Element
    {
        public readonly elementType Type;

        public readonly int value;

        public readonly bool isNum;

        public Element(string token)
        {
            if (Int32.TryParse(token, out int value))
            {
                this.value = value;
                this.Type = elementType.Number;
                this.isNum = true;
            }
            else
            {
                this.isNum = false;
                switch (token)
                {
                    case "*": this.Type = elementType.Multiply; break;
                    case "/": this.Type = elementType.Divide; break;
                    case "+": this.Type = elementType.Add; break;
                    case "-": this.Type = elementType.Subtract; break;
                    case "%": this.Type = elementType.Modulo; break;
                    case "!": this.Type = elementType.Factorial; break;
                    default: throw new ArgumentException("Invalid Input: " + token);
                }
            }
        }

        public Element(int value)
        {
            this.Type = elementType.Number;
            this.value = value;
            this.isNum = true;
        }
    }
}
