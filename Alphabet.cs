using System;
using System.Text;

namespace CodeLouisvilleDemo;

public class Alphabet
{
    //Menu loops until user quits program
    public static void Menu()
    {
        char input;
        string cont = "continue";//string used more than once, variable created to reduce duplication

        while (true)
        {
            Console.Clear();
            Console.WriteLine("How do you want to print the alphabet?\n" +
                              "F: Forward\n" +
                              "B: Backward\n" +
                              "Q: Quit");

            Console.Write("Selection: ");//User inputs shows on same line
            input = Console.ReadKey().KeyChar;

            switch (input)
            {
                //Print alphabet forward
                case 'F' or 'f':
                    Console.WriteLine("\nAlphabet in order\n" +
                                      BuildAlphabetA_Z(Every_n_Letter()) +
                                      Environment.NewLine);
                    Wait(cont);
                    break;
                //Print alphabet backward
                case 'B' or 'b':
                    Console.WriteLine("\nAlphabet in reverse\n" +
                                      BuildAlphabetZ_A(Every_n_Letter()) +
                                      Environment.NewLine);
                    Wait(cont);
                    break;
                //Quit program
                case 'Q' or 'q':
                    return;
                //Invalid input
                default:
                    Console.WriteLine($"\nSelection '{input}' not recognized.\n");
                    Wait("try again");
                    break;
            }
        }
    }

    //Pause program, wait for user to press spacebar to continue
    private static void Wait(string text)
    {
        Console.WriteLine($"Press the spacebar to {text}.");

        bool spacebar = false;

        while (spacebar == false)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                spacebar = true;
        }
        return;
    }

    //Create the alphabet string forwards, showing every n letter
    private static string BuildAlphabetA_Z(int n)
    {
        StringBuilder alphabet = new();

        for (char alpha = 'A'; alpha <= 'Z'; alpha = (char)(alpha + n))
        {
            alphabet.Append(alpha);
        }
        return ShowEvery_n_LetterText(n) + alphabet.ToString();
    }

    //Create the alphabet string backwards, showing every n letter
    public static string BuildAlphabetZ_A(int n)
    {
        StringBuilder alphabet = new();
        //string output;

        for (char alpha = 'Z'; alpha >= 'A'; alpha = (char)(alpha - n))
        {
            alphabet.Append(alpha);
        }
        return ShowEvery_n_LetterText(n) + alphabet.ToString();
    }

    //Returns more output text when skipping letters
    public static string ShowEvery_n_LetterText(int n)
    {
        string clarify = "";
        if (n > 1)
        {
            clarify = $"Showing every {n} letters\n";
        }
        return clarify;
    }

    //public static string PrintAlphabetSkipOneLetter()
    //{
    //    StringBuilder alphabet = new();
    //    for (char alpha = 'A'; alpha <= 'Z'; alpha = (char)(alpha + 2))//cast (alpha + 2) as type char
    //    {
    //        alphabet.Append(alpha);
    //    }
    //    return alphabet.ToString();
    //}

    //Collect input from user
    public static int Every_n_Letter()
    {
        Console.WriteLine("\n\nHow would you like to print the alphabet?\n" +
                          "1: Print all letters\n" +
                          "2: Print every other letter\n" +
                          "or type any other number to print every 'n' letter");
        Console.Write("Enter a value for n: ");

        int n = IsIntegerGreaterThan(0);
        return n;
    }

    //Test user input for validity
    public static int IsIntegerGreaterThan(int x)
    {
        while (true)
        {
            //string? declares string as nullable, and removes warning on Console.ReadLine
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int n))
            {
                if (n > x)
                    return n;
                else
                    Console.Write($"\nSelection must be greater than {x}\n" +
                                  $"Enter a number greater than {x}: "); //loop continues
            }
            else
                Console.Write($"\n{input} is not an integer.\n" +
                                  "Please enter a whole number: ");
        }
    }
}