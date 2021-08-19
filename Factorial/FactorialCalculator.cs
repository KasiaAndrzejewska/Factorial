using System;
using System.Numerics;

namespace Factorial
{
    public class FactorialCalculator
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Put the number to calculate factorial of it \n[Write 'n' and press enter if you want to finish program]");
                String providedValueToCalculate = Console.ReadLine();
                if (providedValueToCalculate == "n")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("\nChoose how to calculate the factorial  \n1 - recursively \n2 - iteratively \n[Write 'n' and press enter if you want to finish program]");
                String providedChoice = Console.ReadLine();

                if (providedChoice == "n")
                {
                    Environment.Exit(0);
                }
                try
                {
                    BigInteger result = CalculateFactorial(providedValueToCalculate, providedChoice);
                    Console.WriteLine("\nYour result: " + result + "\n");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static BigInteger CalculateFactorial(string providedValueToCalculate, string providedChoice)
        {
            int choice = ParseFactorialCalculatonStrategy(providedChoice);

            int valueToCalculate = ParseValueToCalculate(providedValueToCalculate); 

            BigInteger result = 0;
            if (choice == 1)
            {
                result = CalculateFactorialRecursively((BigInteger)valueToCalculate);
            }
            else if (choice == 2)
            {
                result = CalculateFactorialIteratively(valueToCalculate);
            }
            return result;
        }

        private static int ParseValueToCalculate(string providedValueToCalculate)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt32(providedValueToCalculate);
                if (value < 0)
                {
                    throw new ArgumentException("Value cannot be less than 0.");
                }
            }
            catch (System.FormatException e)
            {
                throw new ArgumentException("Provided value is not a number.");
            }
            return value;
        }

        private static int ParseFactorialCalculatonStrategy(string providedChoice)
        {
            int strategy = 0;
            try
            {
                strategy = Convert.ToInt32(providedChoice);
                if (strategy != 1 && strategy != 2)
                {
                    throw new ArgumentException("There is no operation corresponding to that choice.");
                }
            }
            catch (System.FormatException e)
            {
                throw new ArgumentException("Provided strategy is not a number.");
            }            
            return strategy;
        }

        private static BigInteger CalculateFactorialIteratively(int number)
        {
            BigInteger result = 1;
            if (number == 0)
            {
                return 1;
            }
            for (int i = number; i >= 1; i--)
            {
                result *= i;
            }
            return result;
        }

        private static BigInteger CalculateFactorialRecursively(BigInteger number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * CalculateFactorialRecursively(number - 1);
        }
    }
}
