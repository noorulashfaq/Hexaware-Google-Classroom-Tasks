using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> primeNumbers = new List<int>();
        while (true)
        {
            Console.Write("Enter a number (0 to stop): ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0) break;
            if (IsPrime(number)) primeNumbers.Add(number);
        }

        Console.WriteLine("Prime Numbers: " + string.Join(", ", primeNumbers));
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}
