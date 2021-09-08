using System;
using System.Collections.Generic;
using System.Linq;

namespace HangMan
{
    class Program
    {
        static void Main()
        {
            List<string> listWords = new List<string> {
            "jacked", "append", "ripped", "lambda", "caucus", "hugged",
            "skinny", "object", "Squint", "speedy", "ascend"
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


            int failedAttempts = 0;

            while (failedAttempts < randWord.Length)
            {
                Console.WriteLine(string.Join(" ", hiddenWord));
                Console.WriteLine("Guess a letter!");
                char playerGuess = Convert.ToChar(Console.ReadLine());

                if (answerCharList.Contains(playerGuess))
                {


                    for (int i = 0; i < answerCharList.Count; i++)
                    {
                        if (char.ToUpper(answerCharList[i]).Equals(char.ToUpper(playerGuess)))
                        {
                            hiddenWord[i] = Convert.ToString(answerCharList[i]);
                        }
                    }
                }

                Console.Clear();

                if (!answerCharList.Contains(playerGuess))
                {
                    Console.WriteLine("Wrong guess, guess again!");
                    failedAttempts++;
                }

                if (!hiddenWord.Contains("_"))
                {
                    Console.WriteLine("You Win!!!");
                    return;
                }


            }

            Console.WriteLine("You Lose, try again next time!");

        }
    }
}
