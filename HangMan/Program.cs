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
            "skinny", "object", "Squint", "speedy", "ascend",
            "candymaker", "blackmail", "coconut", "fabric", "auspicious", "fallout", "bears", "crunch", "loop"
            };


            Random rng = new Random();
            string randWord = listWords[rng.Next(listWords.Count())];

            List<char> answerCharList = new List<char>();
            List<char> hiddenWord = new List<char>();

            foreach (char item in randWord)
            {
                answerCharList.Add(item);
                hiddenWord.Add('_');
            }


            int failedAttempts = 0;

            while (failedAttempts < randWord.Length + 3)
            {
                Console.WriteLine(string.Join(" ", hiddenWord));

                char playerGuess = ' ';


                bool notALetter = true;
                while (notALetter)
                {
                    Console.WriteLine("Guess a letter!");
                    var input = Console.ReadLine();
                    bool conversionSuccess = char.TryParse(input,out playerGuess);
                    
                    if(conversionSuccess)
                    {
                        notALetter = false;
                    }
                    else
                    {
                        Console.WriteLine("invalid, Please enter only one letter.");
                    }

                }

                Console.Clear();

                if (answerCharList.Contains(playerGuess))
                {


                    for (int i = 0; i < answerCharList.Count; i++)
                    {
                        if (char.ToUpper(answerCharList[i]).Equals(char.ToUpper(playerGuess)))  // case insensitive comparison
                        {
                            hiddenWord[i] = answerCharList[i];
                        }

                    }
                }
                else if (!answerCharList.Contains(playerGuess))
                {
                    Console.WriteLine("Wrong guess, guess again!");
                    failedAttempts++;
                }

                if (!hiddenWord.Contains('_'))
                {
                    Console.WriteLine("You Win!!!");
                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("You Lose, try again next time!");

        }
    }
}
