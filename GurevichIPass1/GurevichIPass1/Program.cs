using System;
using System.IO;

namespace GurevichIPass1
{

    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            string wordleAnswers = File.ReadAllText("WordleAnswers.txt");
            string[] answersArray = wordleAnswers.Split('\n');

            int randNum = rnd.Next(0, answersArray.Length);
            string randWord = (answersArray[randNum]);

            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("─██████──────────██████─██████████████─████████████████───██████─────────████████████───██████─────────██████████████─");
            Console.WriteLine("─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░██─────────██░░░░░░░░████─██░░██─────────██░░░░░░░░░░██─");
            Console.WriteLine("─██░░██──────────██░░██─██░░██████░░██─██░░████████░░██───██░░██─────────██░░████░░░░██─██░░██─────────██░░██████████─");
            Console.WriteLine("─██░░██──██████──██░░██─██░░██──██░░██─██░░████████░░██───██░░██─────────██░░██──██░░██─██░░██─────────██░░██████████─");
            Console.WriteLine("─██░░██──██░░██──██░░██─██░░██──██░░██─██░░░░░░░░░░░░██───██░░██─────────██░░██──██░░██─██░░██─────────██░░░░░░░░░░██─");
            Console.WriteLine("─██░░██──██░░██──██░░██─██░░██──██░░██─██░░██████░░████───██░░██─────────██░░██──██░░██─██░░██─────────██░░██████████─");
            Console.WriteLine("─██░░██████░░██████░░██─██░░██──██░░██─██░░██──██░░██─────██░░██─────────██░░██──██░░██─██░░██─────────██░░██─────────");
            Console.WriteLine("─██░░░░░░░░░░░░░░░░░░██─██░░██████░░██─██░░██──██░░██████─██░░██████████─██░░████░░░░██─██░░██████████─██░░██████████─");
            Console.WriteLine("─██░░██████░░██████░░██─██░░░░░░░░░░██─██░░██──██░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░████─██░░░░░░░░░░██─██░░░░░░░░░░██─");
            Console.WriteLine("─██████──██████──██████─██████████████─██████──██████████─██████████████─████████████───██████████████─██████████████─");
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");

            Console.WriteLine("\n\n\n\t\t\t\t\t|-------|-------|-------|-------|-------|");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
            Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");

            Console.WriteLine("Type your first guess");

            //Guessing Mechanics

            for (int i = 0; i < 6; i++)
            {
                string userGuess = Convert.ToString(Console.ReadLine());

                if (i > 6)
                {
                    Console.WriteLine("you have guessed too many times");
                }
                if (userGuess.Length > 5)
                {
                    Console.WriteLine("Your guess is greater than the 5 letter requirement");
                    Console.ReadLine();

                }
                if (userGuess.Length < 5)
                {
                    Console.WriteLine("Your guess is less than the 5 letter requirement");
                    Console.ReadLine();
                }


                char a = randWord[0];
                char b = randWord[1];
                char c = randWord[2];
                char d = randWord[3];
                char e = randWord[4];

                char a1 = userGuess[0];
                char b1 = userGuess[1];
                char c1 = userGuess[2];
                char d1 = userGuess[3];
                char e1 = userGuess[4];



                if (a == a1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(a1);
                }
                else if (b == a1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(a1);
                }
                else if (c == a1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(a1);
                }
                else if (d == a1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(a1);
                }
                else if (e == a1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(a1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(a1);
                }

                //Second Letter
                if (b == b1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(b1);
                }
                else if (a == b1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(b1);
                }
                else if (c == b1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(b1);
                }
                else if (d == b1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(b1);
                }
                else if (e == b1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(b1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(b1);
                }

                //Third Letter
                if (c == c1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(c1);
                }
                else if (a == c1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(c1);
                }
                else if (b == c1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(c1);
                }
                else if (d == c1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(c1);
                }
                else if (e == c1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(c1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(c1);
                }

                //Fourth Letter
                if (d == d1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(d1);
                }
                else if (a == d1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(d1);
                }
                else if (b == d1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(d1);
                }
                else if (c == d1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(d1);
                }
                else if (e == d1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(d1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(d1);
                }

                //Fifth Letter
                if (e == e1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(e1);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (a == e1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(e1);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (b == e1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(e1);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (c == e1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(e1);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (d == e1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(e1);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e1);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (i > 6)
                    Console.WriteLine("The word was " + randWord);



                Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine("─██████──────────██████─██████████████─████████████████───██████─────────████████████───██████─────────██████████████─");
                Console.WriteLine("─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░██─────────██░░░░░░░░████─██░░██─────────██░░░░░░░░░░██─");
                Console.WriteLine("─██░░██──────────██░░██─██░░██████░░██─██░░████████░░██───██░░██─────────██░░████░░░░██─██░░██─────────██░░██████████─");
                Console.WriteLine("─██░░██──██████──██░░██─██░░██──██░░██─██░░████████░░██───██░░██─────────██░░██──██░░██─██░░██─────────██░░██████████─");
                Console.WriteLine("─██░░██──██░░██──██░░██─██░░██──██░░██─██░░░░░░░░░░░░██───██░░██─────────██░░██──██░░██─██░░██─────────██░░░░░░░░░░██─");
                Console.WriteLine("─██░░██──██░░██──██░░██─██░░██──██░░██─██░░██████░░████───██░░██─────────██░░██──██░░██─██░░██─────────██░░██████████─");
                Console.WriteLine("─██░░██████░░██████░░██─██░░██──██░░██─██░░██──██░░██─────██░░██─────────██░░██──██░░██─██░░██─────────██░░██─────────");
                Console.WriteLine("─██░░░░░░░░░░░░░░░░░░██─██░░██████░░██─██░░██──██░░██████─██░░██████████─██░░████░░░░██─██░░██████████─██░░██████████─");
                Console.WriteLine("─██░░██████░░██████░░██─██░░░░░░░░░░██─██░░██──██░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░████─██░░░░░░░░░░██─██░░░░░░░░░░██─");
                Console.WriteLine("─██████──██████──██████─██████████████─██████──██████████─██████████████─████████████───██████████████─██████████████─");
                Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");

                Console.WriteLine("\n\n\n\t\t\t\t\t|-------|-------|-------|-------|-------|");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|  " + a1 + "    |   " + b1 + "   |  " + c1 + "    |  " + d1 + "    |  " + e1 + "    | ");

                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|  " + a1 + "    |   " + b1 + "   |  " + c1 + "    |  " + d1 + "    |  " + e1 + "    | ");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|  " + a1 + "    |   " + b1 + "   |  " + c1 + "    |  " + d1 + "    |  " + e1 + "    | ");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|  " + a1 + "    |   " + b1 + "   |  " + c1 + "    |  " + d1 + "    |  " + e1 + "    | ");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|  " + a1 + "    |   " + b1 + "   |  " + c1 + "    |  " + d1 + "    |  " + e1 + "    | ");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|  " + a1 + "    |   " + b1 + "   |  " + c1 + "    |  " + d1 + "    |  " + e1 + "    | ");
                Console.WriteLine("\t\t\t\t\t|       |       |       |       |       |");
                Console.WriteLine("\t\t\t\t\t|-------|-------|-------|-------|-------|");
            }


        }

    }
}

