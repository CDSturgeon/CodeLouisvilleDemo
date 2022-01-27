using System;
using System.Text;

namespace CodeLouisvilleDemo;

public class Alphabet
{
    public static string PrintAlphabet()
    {
        StringBuilder alphabet = new();
        for (char alpha = 'A'; alpha <= 'Z'; alpha++)
        {
            alphabet.Append(alpha);
        }
        return alphabet.ToString();
    }

    public static string PrintAlphabetSkipOneLetter()
    {
        StringBuilder alphabet = new();
        for (char alpha = 'A'; alpha <= 'Z'; alpha = (char)(alpha + 2))//cast (alpha + 2) as type char
        {
            alphabet.Append(alpha);
        }
        return alphabet.ToString();
    }

    public static string PrintAlphabetBackwards()
    {
        StringBuilder alphabet = new();
        for (char alpha = 'Z'; alpha >= 'A'; alpha--)
        {
            alphabet.Append(alpha);
        }
        return alphabet.ToString();
    }
}