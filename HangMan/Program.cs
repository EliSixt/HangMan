using System;
using System.Collections.Generic;
using System.Linq;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listWords = new List<string> {
            "jacked", "append", "ripped", "lambda", "Caucus", "Hugged",
            "Skinny", "Object", "Squint", "Speedy", "Ascend"
            };


            Random rng = new Random();
            string randWord = listWords[rng.Next(listWords.Count())];

            List<char> answerCharList = new List<char>();
            List<string> hiddenWord = new List<string>();

            foreach (char item in randWord)
            {
                answerCharList.Add(item);
                hiddenWord.Add("_");
            }

            int attempts = 0;

            while (attempts < randWord.Length + 3)
            {
                Console.WriteLine(string.Join(" ", hiddenWord));
                Console.WriteLine("Guess a letter!");
                char playerGuess = Convert.ToChar(Console.ReadLine());

                if (answerCharList.Contains(playerGuess))
                {
                    for (int i = 0; i < answerCharList.Count; i++)
                    {
                        if (answerCharList[i] == playerGuess)
                        {
                            hiddenWord[i] = Convert.ToString(playerGuess);
                        }
                    }
                }




            }


        }
    }
}
