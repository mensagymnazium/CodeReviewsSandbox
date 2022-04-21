Console.WriteLine(Calculate("2 4 5 + *")); // Should be 18
Console.Write(Calculate("2 3 + 5 *")); // Should be 25

double Calculate(string expression)
{
    var stack = new Stack<double>();
    var tokens = expression.Split(' ');

    foreach (var token in tokens)
    {
        switch (token)
        {
            case "+":
                stack.Push(stack.Pop() + stack.Pop());
                break;
            case "-":
                var right = stack.Pop();
                var left = stack.Pop();
                stack.Push(left - right);
                break;
            case "*":
                stack.Push(stack.Pop() * stack.Pop());
                break;
            case "/":
                right = stack.Pop();
                left = stack.Pop();
                stack.Push(left / right);
                break;
            default:
                stack.Push(double.Parse(token));
                break;
        }
    }

    if (stack.Count == 1) return stack.Pop();
    else throw new InvalidOperationException();
}

// Time Complexity: O(n)
