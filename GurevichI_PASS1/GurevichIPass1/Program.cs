//Author: Idan Gurevich
//File Name: Program.cs
//Project Name: Wordle
//Creation Date: Feb, 09, 2023
//Modified Date: Feb, 23, 2022
//Description: Create a console recreation of the game Wordle

using System;
using System.IO;
using System.Linq;

//Exception variable
Exception? exception = null;

//variable for random
Random random = new();

//Variables for alphabet positioning
int posXAlpha = 37;
int posYAlpha = 5;

//Bools for screen states and if the user is correct
bool titleScreen = true;
bool instructionScreen = false;
bool regularGame = false;
bool statsScreen = false;

//int variables to show starting values of the games played and won
int gamesPlayed = 0;
int gamesWon = 0;
int currentStreak = 0;
int maxStreak = 0;

//Array for the win round distribution
int[] winsDistribution = new int[6];

//The name of the statistics file to read and write into it.
string statisticsFileName = "Statistics.txt";

//String Arrays for the Random words and allowed user guesses
string[] wordleAnswers = File.ReadAllLines("WordleAnswers.txt");
string[] allowedUserGuesses = File.ReadAllLines("WordleExtras.txt");

//2D Char Array for the users letters
char[,] letters = new char[6, 5];

try
{
    //Inputting all the different variables and statisitcs into the statistics file
    string[] lines = File.ReadAllLines(statisticsFileName);
    gamesPlayed = int.Parse(lines[0]);
    gamesWon = int.Parse(lines[1]);
    winsDistribution = new int[6]
        {
            int.Parse(lines[2]),
            int.Parse(lines[3]),
            int.Parse(lines[4]),
            int.Parse(lines[5]),
            int.Parse(lines[6]),
            int.Parse(lines[7]),
        };
    currentStreak = int.Parse(lines[8]);
    maxStreak = int.Parse(lines[9]);
}
catch (Exception statsFileException)
{

}

//Start of a goto, if instruction is true display instructions
Instructions:
if (instructionScreen == true)
{
    Console.Clear();
    Console.WriteLine("Controls:\n- letter keys to input letters\n- left / right arrow: move cursor\n- backspace: delete letter on cursor\n- enter: submit or confirm\n- escape: exit");
    Console.WriteLine("\nIf Letter is Green: The Letter is in the word and the correct spot\nIf Letter is Yellow: The Letter is in the word but in the incorrect spot\nIf the Letter is Gray: The Letter is no in the word");
    Console.WriteLine("\n\nPress Enter to Return to Menu");
    //If enter is not pressed stay on the instructions
    while (Console.ReadKey(true).Key is not ConsoleKey.Enter)
    {


    }
}

//Start of a goto and beginning of code
PlayAgain:
Console.Clear();
Console.WriteLine("Welcome To Wordle!");
Console.WriteLine("Press P to play");
Console.WriteLine("Press I for Instructions");
Console.WriteLine("Press Escape to exit game");

//If title screen is true start allowing user input
if (titleScreen == true)
{
    ConsoleKey key1 = Console.ReadKey(true).Key;

    switch (key1)
    {
        case ConsoleKey.P:
            titleScreen = false;
            regularGame = true;
            goto PlayAgain;

        case ConsoleKey.I:
            instructionScreen = true;
            goto Instructions;

        case ConsoleKey.Escape:
            return;

        default:
            goto PlayAgain;
    }
}
//If regular game is true start the game
if (regularGame == true)
{
    try
    {
        //Set the Color of the letters to White
        Console.ForegroundColor = ConsoleColor.White;

        //Clear the Screen
        Console.Clear();

        //Draw the Gameboard
        Console.WriteLine(
            @"        Wordle

 |---|---|---|---|---|
 |   |   |   |   |   |
 |---|---|---|---|---|
 |   |   |   |   |   |
 |---|---|---|---|---|
 |   |   |   |   |   |
 |---|---|---|---|---|
 |   |   |   |   |   |
 |---|---|---|---|---|
 |   |   |   |   |   |
 |---|---|---|---|---|
 |   |   |   |   |   |
 |---|---|---|---|---|"
        );


        Console.WriteLine("\n");
        //Set the position of the coloums and cursor position
        int guessColoum = 0;
        int cursorPosition = 0;

        //Set a random word
        string word = wordleAnswers[random.Next(wordleAnswers.Length)].ToUpperInvariant();

    //Start of a goto
    GetInput:
        //Set the cursor position to the right of the gameboard
        Console.SetCursorPosition(posXAlpha, posYAlpha);

        //Create a for loop set the letters of the alphabet
        for (char a = 'A'; a <= 'Z'; a++)
        {
            //Create a variable for the foreground color, for easy access
            ConsoleColor backOutColor = Console.ForegroundColor;
            ConsoleColor color = backOutColor;

            //if the user hasn't gussed anything make the alphabet the defualt color
            if (guessColoum > 0)
            {
                //loops through each previous guess while looping through each guess, we also loop through each letter in each of those guesses
                for (int k = 0; color is not ConsoleColor.DarkGreen && k < guessColoum; k++)
                {
                    //loops through each letter in each of the previous guesses
                    for (int j = 0; j < 5; j++)
                    {
                        //if the current letter was ever in the correct position in any of the previous guesses, overide the color the letter appears in the alphabet to be dark green it will break the j for loop
                        //and color is not ConsoleColor.DarkGreen means that the "k" loop will break as well,
                        //so if we ever find a green for that letter it will break out of the loops and output the letter in the alphabet as green
                        if (a == word[j] && word[j] == letters[k, j])
                        {
                            color = ConsoleColor.DarkGreen;
                            break;
                        }
                        //if the letter was ever yellow in a previous guess then we want to override the color to be yellow in the alphabet.
                        //if a letter was yellow on guess #1, but green on guess #2, we need to keep looping. it will see the yellow first and override the color to yellow,
                        //but keep looping and eventually see that the letter was also green and green will override yellow
                        else if (a == letters[k, j] && CheckForYellow(j, word, letters[k, 0], letters[k, 1], letters[k, 2], letters[k, 3], letters[k, 4]))
                        {
                            color = ConsoleColor.DarkYellow;
                        }
                        //If letter is not in the word and guessed by user make it gray
                        else if (color is not ConsoleColor.DarkYellow && a == letters[k, j] && !word.Contains(a))
                        {
                            color = ConsoleColor.DarkGray;
                        }
                    }
                }
            }
            //Writes the character in the alphabet with the color of the letter that corresponds with the for statement above
            Console.ForegroundColor = color;
            Console.Write("|" + a + "|");
            Console.ForegroundColor = backOutColor;

            //If the char in the alphabet is either J or R bring the alphabet to the next line
            if (a is 'J' || a is 'R')
            {
                Console.Write("\n\t\t\t\t\t");
            }
        }

        //Set the cursor position to the beginning of the game board
        Console.SetCursorPosition(3 + cursorPosition * 4, 3 + guessColoum * 2);

        //Allow user input to be read by a key on the keyboard
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case >= ConsoleKey.A and <= ConsoleKey.Z:
                ClearMessageText();

                //Set the cursor position to the beginning of the game board
                Console.SetCursorPosition(3 + cursorPosition * 4, 3 + guessColoum * 2);

                //identifies the letter the user picks
                char c = (char)(key - ConsoleKey.A + 'A');

                //Sets and prints the letter in the position of the gameboard space
                letters[guessColoum, cursorPosition] = c;
                Console.Write(c);

                //Automatically moves the cursor to the next position
                cursorPosition = Math.Min(cursorPosition + 1, 4);
                goto GetInput;

            //If the left arrow is hit move the cursor back
            case ConsoleKey.LeftArrow:
                cursorPosition = Math.Max(cursorPosition - 1, 0);
                goto GetInput;

            //if the right arrow is hit move thre cursor to the right
            case ConsoleKey.RightArrow:
                cursorPosition = Math.Min(cursorPosition + 1, 4);
                goto GetInput;

            //If delete is hit delete the character the cursor is on and go to the left
            case ConsoleKey.Backspace:
                Console.Write(' ');
                Console.CursorLeft--;
                letters[guessColoum, cursorPosition] = ' ';
                cursorPosition = Math.Max(cursorPosition - 1, 0);
                goto GetInput;

            //If enter is pressed go to the CheckForValidLetters method
            case ConsoleKey.Enter:
                if (
                    CheckForValidLetters(
                    letters[guessColoum, 0],
                    letters[guessColoum, 1],
                    letters[guessColoum, 2],
                    letters[guessColoum, 3],
                    letters[guessColoum, 4])

                    //Check to see if the word the letters make are not in the allowedusergusses if they aren't show an error messsage
                    || !allowedUserGuesses.Contains(
                    string.Concat(
                    letters[guessColoum, 0],
                    letters[guessColoum, 1],
                    letters[guessColoum, 2],
                    letters[guessColoum, 3],
                    letters[guessColoum, 4]).ToLowerInvariant())

                    //Check to see if the word the letters make are not in the wordleanswers if they aren't show an error messsage
                    && !wordleAnswers.Contains(
                    string.Concat(
                    letters[guessColoum, 0],
                    letters[guessColoum, 1],
                    letters[guessColoum, 2],
                    letters[guessColoum, 3],
                    letters[guessColoum, 4]).ToLowerInvariant()))
                {
                    ClearMessageText();

                    //Set Cursor Position to under the game board
                    Console.SetCursorPosition(0, 19);

                    //Set background to white and foreground to white and display error if the word is not in the dictionaries given
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("You must input a valid word.");
                    Console.ResetColor();

                    //If the cursor positon is at 0 and user presses enter set background to white and foreground to white and display error that the user needs to input letters
                    if (cursorPosition == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("Please input letters to guess");
                        Console.ResetColor();
                    }
                    goto GetInput;
                }
                //Set correct to true for guesses after 1st row
                bool correct = true;
                //For all five letters loop
                for (int i = 0; i < 5; i++)
                {
                    //Set cursor position to the beginning of the coloumn
                    Console.SetCursorPosition(2 + i * 4, 3 + guessColoum * 2);
                    //If the letter in the word is equal to the letter in the guess and in the right position make it green
                    if (word[i] == letters[guessColoum, i])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    //If in the word but wrong spot go to the CheckForYellow subprogram and make the char yellow
                    else if (
                        CheckForYellow(
                            i,
                            word,
                            letters[guessColoum, 0],
                            letters[guessColoum, 1],
                            letters[guessColoum, 2],
                            letters[guessColoum, 3],
                            letters[guessColoum, 4])
                    )
                    {
                        correct = false;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    //If the letter not in the word make it gray
                    else
                    {
                        correct = false;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    //Print all the letters with their new colors
                    Console.Write($" {letters[guessColoum, i]} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //If The word is correct 1) set cursor position under the game board, 2) Display that the user won and if they want to see stats 3) add 1 to gameswon
                //add 1 to gamesplayed, windistribution and the current streak and then go to the ExportStatisticsToFile subprogram
                if (correct)
                {

                    ClearMessageText();
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("\n\nYou win!");

                    gamesWon++;
                    gamesPlayed++;
                    winsDistribution[guessColoum]++;
                    currentStreak++;
                    ExportStatisticsToFile();

                    //If User wants to play again go back to main game if not end game
                    if (PlayAgainCheck())
                    {
                        goto PlayAgain;
                    }
                    else
                    {
                        return;
                    }
                }

                //If the user didn't win on that coloum go to the next coloum and to the first position for the guess
                else
                {
                    guessColoum++;
                    cursorPosition = 0;
                }

                //If the user reached 6 guesses and hasn't won
                //1) Give user the correct word
                //2) Add 1 to amount of games played and set current streak to 0
                //3) Export the current stats to the stats file
                if (guessColoum > 5)
                {
                    ClearMessageText();
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine($"\n\nYou lose! Word: {word}");
                    gamesPlayed++;
                    currentStreak = 0;
                    ExportStatisticsToFile();

                    //If User wants to play again go back to main game if not end game
                    if (PlayAgainCheck())
                    {
                        goto PlayAgain;
                    }
                    else
                    {
                        return;
                    }
                }
                goto GetInput;
            case ConsoleKey.Escape:
                return;
            case ConsoleKey.End
            or ConsoleKey.Home:
                goto PlayAgain;
            default:
                goto GetInput;
        }
    }
    catch (Exception e)
    {
        exception = e;
        throw;
    }
    finally
    {
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine(exception?.ToString() ?? "Wordle was closed.");
    }
}

//Checks if all 5 letters that user inputs are in between A and Z which doesn't allow the user to actually input numbers and other symbols
bool CheckForValidLetters(char v1, char v2, char v3, char v4, char v5)
{
    if (v1 < 'A' || v1 > 'Z')
        return true;
    if (v2 < 'A' || v2 > 'Z')
        return true;
    if (v3 < 'A' || v3 > 'Z')
        return true;
    if (v4 < 'A' || v4 > 'Z')
        return true;
    if (v5 < 'A' || v5 > 'Z')
        return true;
    return false;
}

//Making sure the right amount of yellow chars exist for the guess
//keep track of the number of that letter that are in the guess, and if any of them are in the correct position (meaning they are green),
//and then all the remaining of that character that have a coresponding letter in the word to guess should be yellow
bool CheckForYellow(int index, string word, params char[] letters)
{
    //Set Variables to 0
    int letterCount = 0;
    int incorrectCountBeforeIndex = 0;
    int correctCount = 0;

    for (int i = 0; i < word.Length; i++)
    {
        if (word[i] == letters[index])
        {
            letterCount++;
        }
        if (letters[i] == letters[index] && word[i] == letters[index])
        {
            correctCount++;
        }

        if (i < index && letters[i] == letters[index] && word[i] != letters[index])
        {
            incorrectCountBeforeIndex++;
        }
    }
    return letterCount - correctCount - incorrectCountBeforeIndex > 0;
}

bool PlayAgainCheck()
{
//Start of Goto
Stats:
    //Checking if stats screen is true and if yes execute the code
    if (statsScreen == true)
    {
        //Clear Console
        Console.Clear();

        //Check if current streak is bigger than max and if yes make max streak the same as current strkea
        if (currentStreak > maxStreak)
        {
            maxStreak = currentStreak;
        }

        //Write Stats title
        Console.WriteLine("Statistics".PadLeft(25));
        Console.WriteLine("________________________________________");

        //Display Stats
        Console.Write("\nYou Have Played: " + gamesPlayed + " Games");
        Console.WriteLine("\t\tYour current streak is: " + currentStreak);
        Console.Write("You Have Won: " + gamesWon + " Games");
        Console.Write("\t\t\tYour max streak is: " + maxStreak);

        //If gamesPlayed is 0 make percentage 0% so no negative number appears
        if (gamesPlayed == 0)
        {
            Console.WriteLine("\n\nYou have won: 0% of your games");
        }

        //If games played is not 0 calculate the true value of the winning percentage and print it
        else
        {
            double winningPercentage = (int)Math.Round((double)(100 * gamesWon) / gamesPlayed);
            Console.WriteLine("\n\nYou have won: " + winningPercentage + "% of your games");
        }

        //Print the Guess distribution title
        Console.WriteLine("\nGUESS DISTRIBUTION");

        //Add a number to the right round the user won 
        for (int i = 0; i < winsDistribution.Length; i++)
        {
            Console.WriteLine($"\t\nGuess #{i + 1}: {winsDistribution[i]}");
        }

        //Display user choices after viewing stats
        Console.Write($"\n\n Play again [enter], quit [escape] or R [Reset Stats]?");

        ConsoleKey key2 = Console.ReadKey(true).Key;

        switch (key2)
        {
            case ConsoleKey.Enter:
                statsScreen = false;
                return true;

            case ConsoleKey.Escape:
                return false;

            //If user presses R restart all the stats and update the stats file with them
            case ConsoleKey.R:
                gamesPlayed = 0;
                gamesWon = 0;
                winsDistribution[0] = 0;
                winsDistribution[1] = 0;
                winsDistribution[2] = 0;
                winsDistribution[3] = 0;
                winsDistribution[4] = 0;
                winsDistribution[5] = 0;
                currentStreak = 0;
                maxStreak = 0;
                ExportStatisticsToFile();
                goto Stats;
        }
    }

    //Print Choices for the user after win or loss
    Console.WriteLine($"\nPlay again [enter], Quit [escape] or Stats [1]?");

GetPlayAgainInput:
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.Enter:
            statsScreen = false;
            return true;
        case ConsoleKey.Escape:
            return false;
        case ConsoleKey.D1:
            statsScreen = true;
            goto Stats;
        default:
            goto GetPlayAgainInput;
    }
}

//Pre: None
//Post: None
//Desc: Clears the error prompts given to user
void ClearMessageText()
{
    Console.ResetColor();
    Console.SetCursorPosition(0, 19);
    Console.WriteLine("                                      ");
    Console.WriteLine("                                      ");
}
//Pre: statistcsFileName, gamesPlayed, gamesWon
//Post: None
//Desc: Exports all stats into a file to safe keep
void ExportStatisticsToFile()
{
    File.WriteAllLines(statisticsFileName, new string[]{ gamesPlayed.ToString(),gamesWon.ToString(),
        winsDistribution[0].ToString(),
        winsDistribution[1].ToString(),
        winsDistribution[2].ToString(),
        winsDistribution[3].ToString(),
        winsDistribution[4].ToString(),
        winsDistribution[5].ToString(),
        currentStreak.ToString(), maxStreak.ToString()});
}