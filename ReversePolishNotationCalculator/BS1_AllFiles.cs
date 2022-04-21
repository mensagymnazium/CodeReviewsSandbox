namespace PolishCalc;

public static class Calculator
{
    public static Fraction Evaluate(string expression)
    {
        Stack<Fraction> stack = new();

        foreach (IToken token in Tokenizer.Tokenize(expression))
        {
            if (token is ValueToken valueToken)
            {
                stack.Push(valueToken.Value);
            }
            else if (token is ArithmeticToken arithmeticToken)
            {
                if (stack.Count < 2) throw new FormatException("Not enough operands");

                Fraction b = stack.Pop();
                Fraction a = stack.Pop();

                switch (arithmeticToken.Type)
                {
                    case ArithmeticTokenType.Addition:
                        stack.Push(a + b);
                        break;
                    case ArithmeticTokenType.Subtraction:
                        stack.Push(a - b);
                        break;
                    case ArithmeticTokenType.Multiplication:
                        stack.Push(a * +b);
                        break;
                    case ArithmeticTokenType.Division:
                        stack.Push(a / b);
                        break;
                }
            }
        }

        if (stack.Count > 1) throw new FormatException("Not enough operators");
        if (stack.Count == 0) throw new FormatException("Expression must not be empty");

        return stack.Pop();
    }
}




using System.Numerics;

namespace PolishCalc;

public struct Fraction : IEquatable<Fraction>
{
    public BigInteger Numerator { get; }
    public BigInteger Denominator { get; }

    public Fraction(BigInteger numerator, BigInteger denominator)
    {
        if (denominator == BigInteger.Zero)
        {
            throw new DivideByZeroException("Denominator must not be zero");
        }

        BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;

        if (Denominator < 0)
        {
            Numerator *= -1;
            Denominator *= -1;
        }
    }

    public Fraction(BigInteger n) : this(n, 1) { }

    public static Fraction operator +(Fraction a)
        => a;

    public static Fraction operator -(Fraction a)
        => new Fraction(-a.Numerator, a.Denominator);

    public static Fraction operator +(Fraction a, Fraction b)
        => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

    public static Fraction operator -(Fraction a, Fraction b)
        => a + -b;

    public static Fraction operator *(Fraction a, Fraction b)
        => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0) throw new DivideByZeroException("Cannot divide by zero");
        return a * b.Invert();
    }

    public static bool operator ==(Fraction a, Fraction b)
        => a.Equals(b);

    public static bool operator !=(Fraction a, Fraction b)
        => !a.Equals(b);

    public static implicit operator Fraction(long n) => new Fraction(n);

    public static implicit operator Fraction(BigInteger n) => new Fraction(n);

    public override bool Equals(object? obj)
    {
        if (obj is Fraction f)
        {
            return Equals(f);
        }

        return false;
    }

    public bool Equals(Fraction f)
    {
        return f.Numerator == Numerator && f.Denominator == Denominator;
    }

    public override int GetHashCode() => (Numerator, Denominator).GetHashCode();

    public Fraction Invert()
    {
        return new Fraction(Denominator, Numerator);
    }

    public override string ToString()
    {
        if (Denominator == 1) return Numerator.ToString();
        return $"{Numerator.ToString()}/{Denominator.ToString()}";
    }
}




using System.Numerics;
using System.Text;

namespace PolishCalc;

internal static class Tokenizer
{
    public static IEnumerable<IToken> Tokenize(string input)
    {
        StringBuilder number = new();

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (Char.IsNumber(c))
            {
                number.Append(c);
            }
            else
            {
                if (number.Length > 0)
                {
                    yield return new ValueToken(BigInteger.Parse(number.ToString()));
                    number = new();
                }

                switch (c)
                {
                    case '+':
                        yield return new ArithmeticToken(ArithmeticTokenType.Addition);
                        break;
                    case '-':
                        yield return new ArithmeticToken(ArithmeticTokenType.Subtraction);
                        break;
                    case '*':
                        yield return new ArithmeticToken(ArithmeticTokenType.Multiplication);
                        break;
                    case '/':
                        yield return new ArithmeticToken(ArithmeticTokenType.Division);
                        break;
                    default:
                        if (!Char.IsWhiteSpace(c)) throw new FormatException($"Unexpected character '{c}'");
                        break;

                }
            }
        }

        if (number.Length > 0)
        {
            yield return new ValueToken(BigInteger.Parse(number.ToString()));
        }
    }
}



using System.Numerics;

namespace PolishCalc;

internal interface IToken { }

record struct ValueToken(BigInteger Value) : IToken;

enum ArithmeticTokenType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

record struct ArithmeticToken(ArithmeticTokenType Type) : IToken;
