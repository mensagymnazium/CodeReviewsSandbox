using System;

namespace ReversePolishNotation
{
  internal class Program
  {
    // tests copied from example
    static void Main(string[] args)
    {
      Test("10 1 +", 11);
      Test("10 1 -", 9);
      Test("10 10 *", 100);
      Test("3 2 /", 1.5);
      Test("2 3 4 + *", 14);
      Test("5 1 2 + 4 * + 3 -", 14);
      // Test("", 0); // error 1
      // Test("1 1 1 +", 0); // error 2
    }

    static void Test(string expression, double expectedResult)
    {
      double actualResult = Calculate(expression);
      Console.WriteLine($"[{(actualResult == expectedResult ? "PASS" : "FAIL")}] {expression} => {actualResult}");
    }

    static double Calculate(string expression)
    {
      Stack<double> stack = new Stack<double>();

      string[] tokens = expression.Split(' ');

      foreach (string token in tokens)
      {
        // push numbers
        if (double.TryParse(token, out double number))
        {
          stack.Push(number);
          continue;
        }

        // not enough operands
        if (stack.Count < 2)
          throw new ArgumentException(Amogus("Tm8gb3BlcmFuZHM/"));

        double a = stack.Pop();
        double b = stack.Pop();

        switch (token)
        {
          case "+":
            stack.Push(b + a);
            break;
          case "-":
            stack.Push(b - a);
            break;
          case "*":
            stack.Push(b * a);
            break;
          case "/":
            stack.Push(b / a);
            break;
          default:
            // invalid operator
            throw new ArgumentException(Amogus("Tm8gb3BlcmFuZHM/"));
        }
      }

      // there are unused operands
      if (stack.Count != 1)
        throw new ArgumentException(Amogus("Tm8gb3BlcmF0b3JzPw=="));

      return stack.Pop();
    }

    // https://cdn.discordapp.com/attachments/802295279781019658/961641692740583444/unknown.png :D
    static string Amogus(string baka) => Sussy("CuKAlOKAlOKAlOKAlOKAlOKAlOKAlOKAlOKAlOKAlOKAlA==") + Sussy(baka) + Sussy("4oCU4oCU4oCU4oCU4oCU4oCU4oCU4oCU4oCU4oCU4oCUCuKggOKjnuKiveKiquKio+Kio+Kio+Kiq+KhuuKhteKjneKhruKjl+Kit+KiveKiveKiveKjruKht+KhveKjnOKjnOKiruKiuuKjnOKit+KiveKineKhveKjnQrioLjiobjioJzioJXioJXioIHiooHioofioo/ior3iorrio6riobPioZ3io47io4/ioq/iop7iob/io5/io7fio7Pioq/iobfio73ior3ioq/io7Pio6vioIcK4qCA4qCA4qKA4qKA4qKE4qKs4qKq4qGq4qGO4qOG4qGI4qCa4qCc4qCV4qCH4qCX4qCd4qKV4qKv4qKr4qOe4qOv4qO/4qO74qG94qOP4qKX4qOX4qCP4qCACuKggOKgquKhquKhquKjquKiquKiuuKiuOKiouKik+KihuKipOKigOKggOKggOKggOKggOKgiOKiiuKinuKhvuKjv+Khr+Kjj+KiruKgt+KggeKggOKggArioIDioIDioIDioIjioIrioIbioYPioJXiopXioofioofioofioofioofioo/ioo7ioo7ioobiooTioIDiopHio73io7/iop3ioLLioInioIDioIDioIDioIAK4qCA4qCA4qCA4qCA4qCA4qG/4qCC4qCg4qCA4qGH4qKH4qCV4qKI4qOA4qCA4qCB4qCh4qCj4qGj4qGr4qOC4qO/4qCv4qKq4qCw4qCC4qCA4qCA4qCA4qCACuKggOKggOKggOKggOKhpuKhmeKhguKigOKipOKio+Kgo+KhiOKjvuKhg+KgoOKghOKggOKhhOKiseKjjOKjtuKij+KiiuKgguKggOKggOKggOKggOKggOKggArioIDioIDioIDioIDiop3iobLio5zioa7ioY/ioo7iooziooLioJnioKLioJDiooDiopjiorXio73io7/iob/ioIHioIHioIDioIDioIDioIDioIDioIDioIAK4qCA4qCA4qCA4qCA4qCo4qO64qG64qGV4qGV4qGx4qGR4qGG4qGV4qGF4qGV4qGc4qG84qK94qG74qCP4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCACuKggOKggOKggOKggOKjvOKjs+Kjq+KjvuKjteKjl+KhteKhseKhoeKio+KikeKileKinOKileKhneKggOKggOKggOKggOKggOKggOKggOKggOKggOKggOKggArioIDioIDioIDio7Tio7/io77io7/io7/io7/iob/iob3ioZHioozioKrioaLioaPio6PioZ/ioIDioIDioIDioIDioIDioIDioIDioIDioIDioIDioIDioIAK4qCA4qCA4qCA4qGf4qG+4qO/4qK/4qK/4qK14qO94qO+4qO84qOY4qK44qK44qOe4qGf4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCA4qCACuKggOKggOKggOKggOKggeKgh+KgoeKgqeKhq+Kiv+KjneKhu+KhruKjkuKiveKgi+KggOKggOKggOKggOKggOKggOKggOKggOKggOKggOKggOKggOKggOKggArigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJTigJQ=");
    static string Sussy(string sus) => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(sus));
  }
}
