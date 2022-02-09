using System;
using System.Text;

namespace CodeLouisvilleDemo;

public class Alphabet
{
    //Menu loops until user quits program
    public static void Menu()
    {
        const string cont = "continue";//string used more than once, variable created to reduce duplication

        while (true)
        {
            Console.Clear();
            Console.WriteLine("How do you want to print the alphabet?\n" +
                              "F: Forward\n" +
                              "B: Backward\n" +
                              "Q: Quit");

            Console.Write("Selection: ");//User inputs shows on same line
            char input = Console.ReadKey().KeyChar;
            string selection = input.ToString().ToUpper();

            switch (selection)
            {
                //Print alphabet forward
                case "F":
                    Console.WriteLine("\nAlphabet in order\n" +
                                      BuildAlphabet('A','Z',selection,Every_n_Letter()) +
                                      Environment.NewLine);
                    Wait(cont);
                    break;
                //Print alphabet backward
                case "B":
                    Console.WriteLine("\nAlphabet in reverse\n" +
                                      BuildAlphabet('Z', 'A', selection, Every_n_Letter()) +
                                      Environment.NewLine);
                    Wait(cont);
                    break;
                //Quit program
                case "Q":
                    Console.WriteLine("\n\nGoodbye.");
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

        while (true)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                return;
        }
    }

    //Create the alphabet string forwards, showing every n letter
    private static string BuildAlphabet(char start, char end, string selection, int n)
    {
        StringBuilder alphabet = new();

        for (char letter = start; KeepLooping(selection,letter, end);)
        {
            alphabet.Append(letter);

            if (selection == "F")
                letter = (char)(letter + n);
            if (selection == "B")
                letter = (char)(letter - n);
        }

        return ShowEvery_n_LetterText(n) + alphabet.ToString();
    }

    //Logic test for the BuildAlphabet 'for' loop
    private static bool KeepLooping(string selection, char letter, char end)
    {
        if (selection == "F")
            return letter <= end;
        if (selection == "B")
            return letter >= end;
        else
            return false;//prevents endless loop
    }

    //Returns more output text when skipping letters
    public static string ShowEvery_n_LetterText(int n)
    {
        if (n > 1)
            return $"Showing every {n} letters\n";

        return "";
    }

    //Collect input from user
    public static int Every_n_Letter()
    {
        Console.WriteLine("\n\nHow would you like to print the alphabet?\n" +
                          "1: Print all letters\n" +
                          "2: Print every other letter\n" +
                          "or type any other number to print every 'n' letter");
        Console.Write("Enter a value for n: ");

        return IsIntegerGreaterThan(0);
    }

    //Test user input for validity
    public static int IsIntegerGreaterThan(int min)
    {
        while (true)
        {
            //string? declares string as nullable, and removes warning on Console.ReadLine
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int n))
            {
                if (n > min)
                    return n;
                else
                    Console.Write($"\nSelection must be greater than {min}\n" +
                                  $"Enter a number greater than {min}: "); //loop continues
            }
            else
                Console.Write($"\n{input} is not an integer.\n" +
                                  "Please enter a whole number: ");
        }
    }
}