using System;

class Program
{
    static void Main()
    {
        // string cardNumber = "2003113438647744";
        Console.Write("Enter card number: ");
        string cardNumber = Console.ReadLine();
        Console.WriteLine(ValidateCard(cardNumber) ? "Valid Card Number" : "Invalid Card Number");
    }

    static bool ValidateCard(string cardNumber)
    {
        int sum = 0;
        bool doubleDigit = true;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = cardNumber[i] - '0';
            
            if (doubleDigit)
            {
                digit *= 2;
                if (digit > 9) 
                    digit = (digit % 10) + 1;
            }

            sum += digit;
            doubleDigit = !doubleDigit;
        }

        return sum % 10 == 0;
    }
}
