namespace ReversePolishNotation;

public class ReversePolishNotationReader
{
    public static double ReadPolishNotation(string str)
    {
        //if num -> save to stack
        //if operand -> perform between two top nums

        string[] instructions = str.Split();
        Stack<double> numbers = new Stack<double>();

        foreach (var op in instructions)
        {
            //is num or operand?
            (InstructionType,ushort) instructionTypeTuple = GetInstructionType(op);
            //if num
            if (instructionTypeTuple.Item1 == InstructionType.Number)
            {
                if (double.TryParse(op,out double num))
                {
                    numbers.Push(num);
                    continue;
                }
                throw new ArgumentException("Input must be a number");
            }

            double n1 = numbers.Pop();
            //if its a 1 number operand
            if (instructionTypeTuple.Item2 == 1)
            {
                switch (instructionTypeTuple.Item1)
                {
                    case InstructionType.Factorial:
                        double res = 2;
                        for (double i = n1; i > 2; i--)
                        {
                            res *= i;
                        }
                        numbers.Push(res);
                        break;
                }
            }
            //if its a 2 number operand
            else if (instructionTypeTuple.Item2 == 2)
            {
                double n2 = numbers.Pop();
                
                switch (instructionTypeTuple.Item1)
                {
                    case InstructionType.Add:
                        numbers.Push(n1 + n2);
                        break;
                    case InstructionType.Subtract:
                        numbers.Push(n2 - n1);
                        break;
                    case InstructionType.Multiply:
                        numbers.Push(n1 * n2);
                        break;
                    case InstructionType.Divide:
                        numbers.Push(n2 / n1);
                        break;
                    case InstructionType.Modulo:
                        numbers.Push(n2 % n1);
                        break;
                    case InstructionType.Power:
                        numbers.Push(Math.Pow(n2, n1));
                        break;
                    case InstructionType.Root:
                        numbers.Push(Math.Pow(n2, 1.0 / n1));
                        break;
                }
            }
        }
            
        return numbers.Pop();
    }


    private static (InstructionType, ushort) GetInstructionType(string c)
    {
        switch (c)
        {
            case "*":
                return (InstructionType.Multiply,2);
            case "/":
                return (InstructionType.Divide,2);
            case "+":
                return (InstructionType.Add,2);
            case "-":
                return (InstructionType.Subtract,2);
            case "pow":
                return (InstructionType.Power,2);
            case "root":
                return (InstructionType.Root,2);
            case "%":
                return (InstructionType.Modulo,2);
            case "!":
                return (InstructionType.Factorial,1);
            
        }

        return (InstructionType.Number,0);
    }
    private enum InstructionType
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Power,
        Root,
        Modulo,
        Factorial,
        Number
    }
}
