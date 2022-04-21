using System; 
using System.Collections.Generic; 
  
Console.WriteLine(Test("10 1 +")); 
Console.WriteLine(Test("10 1 -")); 
Console.WriteLine(Test("10 10 *")); 
Console.WriteLine(Test("3 2 /")); 
Console.WriteLine(Test("2 3 4 + *")); 
Console.WriteLine(Test("5 1 2 + 4 * + 3 -")); 
  
double Test(string input) 
{ 
    var stack = new Stack<double>(); 
    var array = input.Split(" "); 
  
    var operations = new Dictionary<string, Func<double, double, double>>() 
    { 
        { "+", (a, b) => a + b }, 
        { "-", (a, b) => a - b }, 
        { "*", (a, b) => a * b }, 
        { "/", (a, b) => a / b }, 
        { "^", (a, b) => Math.Pow((double)a,(double)b)} 
    }; 
  
    for (int i = 0; i < array.Length; i++)//todo 
    { 
        if (double.TryParse(array[i], out double number)) 
        { 
            stack.Push(number); 
        } 
        else if (operations.TryGetValue(array[i], out var func)) 
        { 
            var op2 = stack.Pop(); 
            stack.Push(func(stack.Pop(), op2)); 
        } 
    } 
    return stack.Pop(); 
} 
