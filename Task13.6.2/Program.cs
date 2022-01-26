using System;
using System.Collections.Generic;
using System.Linq;

namespace Task13._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var noPunctuationText = new string(System.IO.File.ReadAllText("text1.txt")
                .Where(c => !char.IsPunctuation(c)).ToArray()).Split(new char[] { ' ', '\n' });
            var listStrings = new List<string>(noPunctuationText);
            listStrings.RemoveAll(i => i == string.Empty);
            var result = listStrings.GroupBy(i => i)
                .Select(i => new { Слово = i.Key, Количество = i.Count() }).OrderByDescending(i => i.Количество);
            int counter = 0;
            foreach (var i in result)
            {
                if (counter == 10) break;
                Console.WriteLine($"Слово '{i.Слово}' встречается {i.Количество} раз");
                counter++;
            }
            Console.ReadKey();
        }
    }
}
