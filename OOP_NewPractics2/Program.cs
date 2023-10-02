using System;
using System.Text.RegularExpressions;

class Program
{
    static void PairChars(string sampleString)
    {
        int charPair = 0;
        for (int i = 0; i < sampleString.Length - 1; i++)
        {
            if (sampleString[i] == sampleString[i + 1])
            {
                charPair++;
            }
        }
        Console.WriteLine("Кількість пар (однакових сусідніх) символів: {0}", 
                                                                    charPair);
    }
    static string NumberFormatting(string number)
    {
        if (Regex.IsMatch(number, @"\d"))
        {
            List<string> chapters = new();
            switch (number.Length % 2 == 0)
            {
                case true:
                    for (int i = 0; i < (number.Length / 2); i++)
                    {
                        chapters.Add(number.Substring(i * 2, 2));
                    }
                    break;
                case false:
                    chapters.Add(number[..1]);
                    for (int i = 0; i < (number.Length / 2); i++)
                    {
                        chapters.Add(number.Substring(i * 2 + 1, 2));
                    }
                    break;
            }
            string formattedNumber = string.Join('-', chapters);
            return formattedNumber;
        }
        else
        {
            return "Введення не є числом або номером.";
        }
    }
    static void LengthSort(string sentence)
    {
        string[] sentenceCache = sentence.Split(" ");
        Array.Sort(sentenceCache, (x, y) => x.Length.CompareTo(y.Length));
        foreach (string word in sentenceCache)
        {
            Console.WriteLine(word);
        }
    }
    static string AlphabetSort(string sentence)
    {
        List<string> sentenceWords = new();
        string[] sentenceCache = sentence.Split(" ");
        foreach (string word in sentenceCache)
        {
            sentenceWords.Add(word);
        }
        sentenceWords.Sort();
        for (int i = 0; i < sentenceWords.Count; i++)
        {
            if (i > 0)
            {
                while (sentenceWords[i].ToLower() ==
                       sentenceWords[i - 1].ToLower())
                {
                    sentenceWords.RemoveAt(i);
                }
            }
        }
        string outputSentence = string.Join(' ', sentenceWords);
        return outputSentence;
    }
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("Введіть текст: ");
        string inputString = Console.ReadLine();
        PairChars(inputString);
        Console.WriteLine("\nВведіть номер: ");
        string inputNumber = Console.ReadLine();
        string outputNumber = NumberFormatting(inputNumber);
        Console.WriteLine("Номер може мати такий вигляд: {0}",
                                                 outputNumber);
        Console.WriteLine("\nВведіть текст: ");
        string iSentenceSort = Console.ReadLine();
        LengthSort(iSentenceSort);
        Console.WriteLine("\nВведіть текст: ");
        string? iSentenceABet = Console.ReadLine();
        string oSentenceABet = AlphabetSort(iSentenceABet);
        Console.WriteLine("Вихідне речення: {0}", oSentenceABet);
    }
}