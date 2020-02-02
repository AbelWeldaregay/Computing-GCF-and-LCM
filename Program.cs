﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Base
{
    class Program
    {
        /**
         * Holds the prime factors of the first number passed
         */
        private static List<int> primeFactorA = new List<int>();
        /**
        * Holds the prime factores of the second number passed
        */
        private static List<int> primeFactorB = new List<int>();
        /**
        * Driver method
        */
        static void Main(string[] args)
        {
            int a = -1, b = -1;
            string sa, sb;

            bool isContinue = true;

            while (isContinue)
            {
                bool aValid = false, bValid = false;
                Console.WriteLine("Enter the first number:");
                while (!aValid)
                {
                    sa = Console.ReadLine();
                    try
                    {
                        a = Int32.Parse(sa);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sa);
                    }
                    if (a < 1 || a > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        aValid = true;
                }

                Console.WriteLine("Enter the second number:");
                while (!bValid)
                {
                    sb = Console.ReadLine();
                    try
                    {
                        b = Int32.Parse(sb);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sb);
                    }
                    if (b < 1 || b > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        bValid = true;
                }

                // Enter your code here.
                primeFactorA = calculatePrimeFactors(a);
                primeFactorB = calculatePrimeFactors(b);

                Console.WriteLine("The factors of " + a + " are: ");

                Console.WriteLine(String.Join(" ", primeFactorA));

                Console.WriteLine("The factors of " + b + " are: ");
                Console.WriteLine(String.Join(" ", primeFactorB));
                Console.WriteLine("The GCF of " + a + " and " + b + " are: ");
                Console.WriteLine(String.Join(" ", calculatePrimeFactors(greatestCommonFactor(a, b))));
                Console.WriteLine("The LCM of " + a + " and " + b + " are: ");
                Console.WriteLine(leastCommonMultiple(a, b));

                Console.WriteLine("\nDo you want to continue? Y/N");
                string newLoop = Console.ReadLine();
                if (newLoop[0] == 'Y' || newLoop[0] == 'y')
                {
                    Console.WriteLine();
                    isContinue = true;
                }
                else
                    isContinue = false;
            }
        }
        /**
         * Calculates the prime factors of a given number
         * @param num: the number to calculate the prime factors for
         * @return a List<int> prime factors
         */
        public static List<int> calculatePrimeFactors(int num)
        {
            List<int> primeFactors = new List<int>();

            for (int i = 2; i <= Math.Sqrt(num); ++i)
            {
                if (num % i == 0)
                {
                    while (num % i == 0)
                    {
                        primeFactors.Add(i);
                        num = num / i;
                    }
                }
            }
            if (num != 1)
            {
                primeFactors.Add(num);
            }
            return primeFactors;
        }
        /**
         * Calculates the least common multiples using |a*b|/GCF(a, b)
         * @param a: the first number to be used in calculating LCM
         * @param b: the second number to be used in calculating LCM
         * @return true if all barks were successful.
         */
        public static int leastCommonMultiple(int a, int b) {

            if (a == 0 || b == 0)
                return 0;
          
            return Math.Abs(a*b) / greatestCommonFactor(a, b); 
        }

        /**
         * Calculates the greatest commn factor of two given numbers
         * @param a: the first number to be used in calculating GCF
         * @param b: the second number to be used in calculating GCF
         * @return int: the greatest common factor
         */
        public static int greatestCommonFactor(int a, int b) 
        {
            int divisor = Math.Max(a, b);
            int remainder = a % b;
            int prev_remainder = remainder;

            while (remainder != 0)
            {
                prev_remainder = remainder;
                remainder = divisor % remainder;
            }

            return prev_remainder;
        }
    }
}
