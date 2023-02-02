using System;

namespace Calculator
{
    interface ICalculator
    {
        double Add(double a, double b);
    }

    class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This calculator will get the sum of two entered numbers.\nEnter the first number:");
            string firstNumber = Console.ReadLine();

            Console.WriteLine("Enter the second number:");
            string secondNumber = Console.ReadLine();

            ICalculator calculator = new Calculator();

            try
            {
                double a = Convert.ToDouble(firstNumber);
                double b = Convert.ToDouble(secondNumber);
                double result = calculator.Add(a, b);

                Console.WriteLine("The result is: " + result);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[INFO] The result of adding {0} and {1} is {2}", a, b, result);
                Console.ResetColor();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid input, only numbers are allowed.");
                Console.ResetColor();
            }
        }
    }
}

