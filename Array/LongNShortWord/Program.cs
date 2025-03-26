using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter words separated by comma: ");
        string inputWords = Console.ReadLine();

        string[] words = inputWords.Split(',');

        string longestWord = words[0].Trim();
        string shortestWord = words[0].Trim();

        foreach (string word in words)
        {
            string trimmed = word.Trim();

            if (trimmed.Length > longestWord.Length)
            {
                longestWord = trimmed;
            }

            if (trimmed.Length < shortestWord.Length)
            {
                shortestWord = trimmed;
            }
        }

        Console.WriteLine("Longest Word: " + longestWord);
        Console.WriteLine("Shortest Word: " + shortestWord);
    }
}
