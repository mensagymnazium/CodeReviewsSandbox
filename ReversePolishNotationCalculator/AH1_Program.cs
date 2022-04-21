static double Test(string input) 
{ 
    var stack = new Stack<double>(); 
    var inputs = input.Split(' '); 
    foreach (var i in inputs) 
    { 
        if (i == "+") 
        { 
            double number1 = stack.Pop(); 
            double number2 = stack.Pop(); 
            stack.Push(number2 + number1); 
            break; 
        } 
        if (i == "-") 
        { 
            double number1 = stack.Pop(); 
            double number2 = stack.Pop(); 
            stack.Push(number2 - number1); 
            break; 
        } 
        if (i == "*") 
        { 
            double number1 = stack.Pop(); 
            double number2 = stack.Pop(); 
            stack.Push(number2 * number1); 
            break; 
        } 
        if (i == "/") 
        { 
            double number1 = stack.Pop(); 
            double number2 = stack.Pop(); 
            stack.Push(number2 / number1); 
            break; 
        }       
            stack.Push(double.Parse(i)); 
         
    } 
    return stack.Pop(); 
  
} 
  
Console.WriteLine(Test("10 1 +")); 
Console.WriteLine(Test("10 1 -")); 
Console.WriteLine(Test("10 10 *")); 
Console.WriteLine(Test("3 2 /")); 
Console.WriteLine(Test("2 3 4 + *")); 
Console.WriteLine(Test("5 1 2 + 4 * + 3 -")); 
  
 
 
