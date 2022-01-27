using System;
using System.Text;

namespace CodeLouisvilleDemo;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Alphabet in order\n" + Alphabet.PrintAlphabet() + Environment.NewLine);

        Console.WriteLine("Every other letter\n" + Alphabet.PrintAlphabetSkipOneLetter() + Environment.NewLine);

        Console.WriteLine("Alphabet in reverse\n" + Alphabet.PrintAlphabetBackwards() + Environment.NewLine);
    }
}