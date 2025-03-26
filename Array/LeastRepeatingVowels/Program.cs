using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter words separated by comma: ");
        string input = Console.ReadLine();
        string[] words = input.Split(',');

        int min = int.MaxValue;
        string result = "";

        foreach (string word in words)
        {
            int vowels = CountRepeatingVowels(word.Trim());
            if (vowels < min)
            {
                min = vowels;
                result = word;
            }
            else if (vowels == min)
            {
                result += ", " + word;
            }
        }

        Console.WriteLine($"Words with least repeating vowels: {result}");
    }

    static int CountRepeatingVowels(string word)
    {
        var vowels = "aeiouAEIOU";
        int[] counts = new int[256];
        int repeats = 0;

        foreach (char c in word)
        {
            if (vowels.Contains(c))
            {
                counts[c]++;
                if (counts[c] > 1)
                {
                    repeats++;
                }
            }
        }

        return repeats;
    }
}
