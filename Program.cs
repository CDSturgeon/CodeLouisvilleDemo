using System;
using System.Text;

namespace CodeLouisvilleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alphabet in order\n" + PrintAlphabet() + Environment.NewLine);
            Console.WriteLine("Every other letter\n" + PrintAlphabetSkipOneLetter() + Environment.NewLine);
            Console.WriteLine("Alphabet in reverse\n" + PrintAlphabetBackwards() + Environment.NewLine);
        }

        public static string PrintAlphabet()
        {
            StringBuilder alphabet = new StringBuilder();
            for (char alpha = 'A'; alpha <= 'Z'; alpha++)
            {
                alphabet.Append(alpha);
            }
            return alphabet.ToString();
        }

        public static string PrintAlphabetSkipOneLetter()
        {
            StringBuilder alphabet = new StringBuilder();
            for (char alpha = 'A'; alpha <= 'Z'; alpha = (char) (alpha + 2))
            {
                alphabet.Append(alpha);
            }
            return alphabet.ToString();
        }

        public static string PrintAlphabetBackwards()
        {
            StringBuilder alphabet = new StringBuilder();
            for (char alpha = 'Z'; alpha >= 'A'; alpha--)
            {
                alphabet.Append(alpha);
            }
            return alphabet.ToString();
        }
    }
}