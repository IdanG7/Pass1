using System;
using System.IO;

namespace GurevichIPass1
{

    class Program
    {

        static void Main(string[] args)
        {
            Game wordleGame = new Game();
            wordleGame.WordleGame();
        }
    }

    class Game
    {
        static Random rnd = new Random();

        public void WordleGame()
        {
            string wordleAnswers = File.ReadAllText("WordleAnswers.txt");
            string[] answersArray = wordleAnswers.Split('\n');

            int randNum = rnd.Next(0, answersArray.Length);
            string randWord = answersArray[randNum];

            CreateMainScreen();




            static void CreateMainScreen()
            {
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


            }



        }
    }
}
