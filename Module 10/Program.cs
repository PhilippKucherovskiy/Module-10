using System;

namespace CalculatorWithLogger
{
    public interface ICalculator
    {
        int Sum(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Event: " + message);
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();
            ILogger logger = new Logger();

            while (true)
            {
                Console.WriteLine("Enter first number:");
                string input1 = Console.ReadLine();
                int a;

                Console.WriteLine("Enter second number:");
                string input2 = Console.ReadLine();
                int b;

                try
                {
                    a = int.Parse(input1);
                    b = int.Parse(input2);
                }
                catch (FormatException)
                {
                    logger.Error("Invalid input format. Input must be an integer.");
                    continue;
                }

                int sum = calculator.Sum(a, b);
                Console.WriteLine("Sum: " + sum);
                logger.Event("The sum of " + a + " and " + b + " is " + sum);
            }
        }
    }
}
