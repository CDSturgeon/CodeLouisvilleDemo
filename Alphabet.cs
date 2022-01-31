using System;
using System.Text;

namespace CodeLouisvilleDemo;

public class Alphabet
{
    public static void Menu()
    {
        char input;

        Console.Clear();
        Console.WriteLine("How do you want to print the alphabet?\n" +
                              "F: Forward\n" +
                              "B: Backward\n" +
                              "Q: Quit");

        input = Console.ReadKey().KeyChar;
        switch (input) //Switch on Key enum
        {
            case 'F' or 'f':
                Console.WriteLine("\nAlphabet in order\n" + Alphabet.PrintAlphabet() + Environment.NewLine);
                Wait("continue");
                break;
            case 'B' or 'b':
                Console.WriteLine("\nAlphabet in reverse\n" + Alphabet.PrintAlphabetBackwards() + Environment.NewLine);
                Wait("continue");
                break;
            case 'Q' or 'q':
                return;
            default:
                Console.WriteLine($"\nSelection '{input}' not recognized.\n");
                Wait("try again");
                break;
        }
    }

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

    private static string PrintAlphabet()
    {
        int x = EveryXLetter();
        StringBuilder alphabet = new();

        for (char alpha = 'A'; alpha <= 'Z'; alpha = (char)(alpha + x))
        {
            alphabet.Append(alpha);
        }
        return alphabet.ToString();
    }

    public static string PrintAlphabetBackwards()
    {
        int x = EveryXLetter();
        StringBuilder alphabet = new();

        for (char alpha = 'Z'; alpha >= 'A'; alpha = (char)(alpha - x))
        {
            alphabet.Append(alpha);
        }
        return alphabet.ToString();
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

    public static int EveryXLetter()
    {
        Console.WriteLine("\nHow would you like to print the alphabet?\n" +
                          "1: Print all letters\n" +
                          "2: Print every other letter\n" +
                          "or type any other number to print every 'x' letter\n");

        while (true)
        {
            //string? declares string as nullable, and removes warning on Console.ReadLine
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                if (x > 0)
                    return x;
                else
                {
                    Console.WriteLine("\nSelection must be greater than 0"); //loop continues
                }
            }
            else
            {
                Console.WriteLine($"\n{input} is not an integer.\n" +
                                  "Please enter a whole number:");
            }
        }        
    }
}