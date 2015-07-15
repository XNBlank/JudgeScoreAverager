using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JudgeScoreAverager
{
    class Program
    {
        static void ResetDialogue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the score average calculator.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please make sure your scores have the same top score (?/10).");
            Console.ResetColor();
            HighScore();
        }

        static void HighScore()
        {
            Console.WriteLine("\nWhat is the highest possible score?");
            string highscoreinput = Console.ReadLine();
            int highscore;

            try
            {
                highscore = Convert.ToInt32(highscoreinput);
                if (highscore <= 0)
                {
                    Console.WriteLine("\nYou can't have a highscore of " + highscore);
                    HighScore();
                }
                else
                {
                    Console.WriteLine("\nYou set the highest score to " + highscore);
                    Judges(highscore);
                }
            }
            catch
            {
                Console.WriteLine("\nInvalid entry.");
                HighScore();
            }
        }

        static void Judges(int highscore)
        {
            Console.WriteLine("\nPlease enter the amount of Judges.");

            string judgeinput = Console.ReadLine();
            int totalJudges;

            try
            {
                totalJudges = Convert.ToInt32(judgeinput);

                if (totalJudges <= 0)
                {
                    Console.WriteLine("\nYou cannot have " + totalJudges + " judges.");
                    ResetDialogue();
                }
                else
                {
                    Score(totalJudges, highscore);
                }
            }
            catch
            {
                Console.WriteLine("\nInvalid Entry.");
                Judges(highscore);
            }
        }

        static void Score(int totalJudges, int highscore)
        {
            List<float> scoreList = new List<float>();

            for (int i = 0; i < totalJudges; i++)
            {
                Console.WriteLine("\nPlease input a score.");

                string uinput1 = Console.ReadLine();
                float aNumber;

                try
                {
                    aNumber = Convert.ToSingle(uinput1);

                    if (aNumber > highscore)
                    {
                        Console.WriteLine("\nYou can't have a score higher than the highest score.");
                        i--;
                    }
                    else
                    {
                        scoreList.Add(aNumber);
                    }
                    
                }
                catch
                {
                    Console.WriteLine("\nInvalid entry.");
                    i--;
                }
            }

            Console.WriteLine("\n\nList of input scores\n");

            foreach (float ii in scoreList)
            {
                Console.WriteLine(ii);
            }

            Console.WriteLine("\nYour average score is " + Math.Round(scoreList.Average(), 3) + "\n\n");
            AskRestart();

        }

        static void AskRestart()
        {
            Console.WriteLine("\nWould you like to average another score? (Y/N)\n");

            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                    Console.Clear();
                    ResetDialogue();
                    break;
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    AskRestart();
                    break;
            }
        }

        static void Main(string[] args)
        {
            ResetDialogue();
        }
    }
}
