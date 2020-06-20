using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Labb4
{
    class Program
    {
        static readonly string fileLocation = Path.Combine(Environment.CurrentDirectory, "pg5200.txt");
        static void Main(string[] args)
        {
            var TheWholeFile = " ";
            using (var StreamReader = new StreamReader("pg5200.txt"))
            {
                TheWholeFile = StreamReader.ReadToEnd();
            }

            Tree tree = new Tree();
            var listOfWords = GetAllWords(TheWholeFile);

            Node root = null;
            for (int i = 0; i < listOfWords.Length; i++)
            {
                root = tree.CountingFrequenciesOfEachWord(root, listOfWords[i]);
            }
            var keyvaluePairs = tree.DisplayFrequencies(root);
            using (StreamWriter writer = new StreamWriter(new FileStream("Result.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                foreach (var item in keyvaluePairs)
                {
                    writer.WriteLine($"{item.Key}, {item.Value}");
                }
            }
        }

        /// <summary>
        /// Tar bort alla icke alfabetiska tecken och splittar en sträng på mellanslag till en array.
        /// </summary>
        /// <param name="str">Strängen du vill rensa och splitta</param>
        /// <returns>En array med alla ord i strängen</param>
        static string[] GetAllWords(string str)
        {
            var words = Regex.Replace(str, @"[^\w\d\@\- ]", " ")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
            return words;
        }

    }
}
