 
  
var Caluculator = new Encoder(); 
Test("10 1 +", 11); 
Test("10 1 -", 9); 
Test("10 10 *", 100); 
Test("3 2 /", 1.5); 
Test("2 3 4 + *", 14); 
Test("5 1 2 + 4 * + 3 -", 14); 
  
void Test (string RPN, double Guess) 
{ 
    Caluculator.Encode(RPN); 
    double i = Caluculator.Result; 
    if (i == Guess) 
    { 
        Console.WriteLine($"{i},ok"); 
    } 
    else Console.WriteLine($"{i},not ok"); 
} 
  
public class Encoder 
    { 
    public double Result { get; set; } 
      
  
        public void Encode (string RPN) 
    { 
        var stack = new Stack<double>(); 
        var chars = RPN.Split(' '); 
  
        for (int i = 0; i < chars.Length; i++) 
        { 
            var v = chars[i]; 
            if (v == "+" || v == "-" || v == "*" || v == "/") 
            { 
                if (v=="+") 
                { 
                    double x= stack.First(); 
                    stack.Pop(); 
                    double y= stack.First(); 
                    stack.Pop(); 
                    stack.Push(x + y); 
  
                } 
                if (v=="-") 
                { 
                    double x= stack.First(); 
                    stack.Pop(); 
                    double y= stack.First(); 
                    stack.Pop(); 
                    stack.Push(y - x); 
  
                }if (v=="*") 
                { 
                    double x= stack.First(); 
                    stack.Pop(); 
                    double y= stack.First(); 
                    stack.Pop(); 
                    stack.Push(x * y); 
  
                }if (v=="/") 
                { 
                    double x= stack.First(); 
                    stack.Pop(); 
                    double y= stack.First(); 
                    stack.Pop(); 
                    stack.Push(y / x); 
  
                } 
  
            } 
            else stack.Push(Convert.ToDouble(v)); 
        } 
        Result = stack.First(); 
    } 
  
  
    } 
 
