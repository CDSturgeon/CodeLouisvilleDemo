using System;
using System.Text;

namespace CodeLouisvilleDemo;

class Program
{
    static void Main(string[] args)
    {
        Menu();
        Console.WriteLine("\n\nGoodbye.");
    }

    static void Menu()
    {
        char input = new();
        while (input != 'Q' || input != 'q')
        {
            Console.Clear();
            Console.WriteLine("How do you want to print the alphabet?\n" +
                              "F: Forward\n" +
                              "B: Backward\n" +
                              "Q: Quit");

            input = Console.ReadKey().KeyChar;

            switch (input) //Switch on Key enum
            {
                case 'F' or 'f':
                    Console.WriteLine("\n\nAlphabet in order\n" + Alphabet.PrintAlphabet() + Environment.NewLine);
                    Wait();
                    break;
                case 'B' or 'b':
                    Console.WriteLine("\n\nAlphabet in reverse\n" + Alphabet.PrintAlphabetBackwards() + Environment.NewLine);
                    Wait();
                    break;
                case 'Q' or 'q':
                    return;
                default:
                    Console.WriteLine($"\n\nSelection '{input}' not recognized. Try again.\n");
                    Wait();
                    break;
            }
        }
        //Console.WriteLine("Every other letter\n" + Alphabet.PrintAlphabetSkipOneLetter() + Environment.NewLine);
    }

    static void Wait()
    {
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        return;
    }
}