using System;
using System.Text;
using CLLibrary;
using System.Linq;

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

            var menu = new List<KeyValuePair<char, string>>
            {
                new KeyValuePair<char, string>('A', "Print the alphabet"),
                new KeyValuePair<char, string>('Z', "Print the alphabet backwards"),
                new KeyValuePair<char, string>('Q', "Quit")
            };

            char input = CLAppBase.Prompt4MenuItem("Please select from the following options:", menu);
            switch (input.ToString().ToUpper())
            {
                //Print alphabet forward
                case "A":
                    Console.WriteLine("\nAlphabet in order\n" +
                                      BuildAlphabetA_Z(Every_n_Letter()) +
                                      Environment.NewLine);
                    CLAppBase.Wait(cont);
                    break;
                //Print alphabet backward
                case "Z":
                    Console.WriteLine("\nAlphabet in reverse\n" +
                                      BuildAlphabetZ_A(Every_n_Letter()) +
                                      Environment.NewLine);
                    CLAppBase.Wait(cont);
                    break;
                //Quit program
                case "Q":
                    Console.WriteLine("\n\nGoodbye.");
                    return;
                //Invalid input
                default:
                    Console.WriteLine($"\nSelection {input} not recognized.\n");
                    CLAppBase.Wait("try again");
                    break;
            }
        }
    }

    //Create the alphabet string forwards, showing every n letter
    private static string BuildAlphabetA_Z(int n)
    {
        StringBuilder alphabet = new();

        for (char letter = 'A'; letter <= 'Z'; letter += (char)n)
        {
            alphabet.Append(letter);
        }

        return ShowEvery_n_LetterText(n) + alphabet.ToString();
    }

    //Create the alphabet string backwards, showing every n letter
    private static string BuildAlphabetZ_A(int n)
    {
        StringBuilder alphabet = new();

        for (char letter = 'Z'; letter >= 'A'; letter -= (char)n)
        {
            alphabet.Append(letter);
        }

        return ShowEvery_n_LetterText(n) + alphabet.ToString();
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
        var menu = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("1", "Print all letters"),
            new KeyValuePair<string, string>("2", "Print every other letter"),
            new KeyValuePair<string, string>("n", "Type a number less than 26 to print every 'n' letter")
        };

        string selection = CLAppBase.Prompt4MenuItem("\n\nHow would you like to print the alphabet?", menu);
        while (!CLAppBase.IsIntegerGreaterBetween(selection, 0, 26))
        {
            selection = Console.ReadLine();
        }

        return int.Parse(selection);
    }
}