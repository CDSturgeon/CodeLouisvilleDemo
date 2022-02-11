using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLLibrary;

public class CLAppBase
{
    public static int Prompt4Integer(string prompt)
    {
        int value;
        do
        {
            Console.Write(prompt);
        }
        while (!int.TryParse(Console.ReadLine(), out value));
        return value;
    }

    public static bool Prompt4YesNo(string prompt)
    {
        char userInput;
        do
        {
            Console.Write(prompt);
            userInput = Console.ReadKey().KeyChar;
        } while (userInput.ToString().ToUpper() != "Y" && userInput.ToString().ToUpper() != "N");

        return userInput.ToString().ToUpper() == "Y";
    }

    public static char Prompt4MenuItem(string prompt, List<KeyValuePair<char, string>> menu)
    {
        Console.WriteLine(prompt);
        // this is the menu
        foreach (KeyValuePair<char, string> menuItem in menu)
        {
            Console.WriteLine($"\t{menuItem.Key}: {menuItem.Value}");
        }
        Console.Write("Selection: ");
        return Console.ReadKey().KeyChar;
    }

    public static string Prompt4MenuItem(string prompt, List<KeyValuePair<string, string>> menu)
    {
        Console.WriteLine(prompt);
        // this is the menu
        foreach (KeyValuePair<string, string> menuItem in menu)
        {
            Console.WriteLine($"\t{menuItem.Key}: {menuItem.Value}");
        }
        Console.Write("Selection: ");
        return Console.ReadLine();
    }

    public static bool TryPrompt4Integer(out int value,
                                            string prompt = "",
                                            uint maxAttempts = 0,
                                            int minValue = int.MinValue,
                                            int maxValue = int.MaxValue)
    {
        if (minValue > maxValue)
            throw new ArgumentException("minValue must be <= maxValue");

        if (string.IsNullOrWhiteSpace(prompt))
        {
            StringBuilder newPrompt = new StringBuilder("Enter a number");
            if (minValue != int.MinValue)
                newPrompt.Append($" >= {minValue}");
            if (minValue != int.MinValue && maxValue != int.MaxValue)
                newPrompt.Append(" and");
            if (maxValue != int.MaxValue)
                newPrompt.Append($" <= {maxValue}");
            if (maxAttempts > 0)
                newPrompt.Append($" (You will get {maxAttempts} tries)");
            newPrompt.Append(": ");
            prompt = newPrompt.ToString();
        }

        bool success = false;
        uint attempt = 0;
        bool quit = false;

        do
        {
            if (maxAttempts > 0) // if user has a limited number of attempts
            {
                attempt++;
                WriteRetryPrompt(attempt, maxAttempts);
            }
            Console.Write(prompt);
            success = int.TryParse(Console.ReadLine(), out value);
            if (!success)
                Console.WriteLine("Entry is not a number.");
            else if (value < minValue || value > maxValue)
            {
                // they entered a number but it's outside of the range
                // we wanted
                success = false;
                Console.WriteLine($"Input must be between {minValue} and {maxValue}");
            }
        // quit when they've entered a number like we've asked
        // OR they've exceeded the maximum number of allowed attempts
        quit = success || attempt >= maxAttempts;
            if (!quit) Console.WriteLine();
        } while (!quit);

        return success;
    }

    public static bool TryPrompt4YesNo(string prompt, out bool response, uint maxAttempts = 0, string yesResponse = "Y", string noResponse = "N")
    {
        if (string.IsNullOrWhiteSpace(prompt))
            prompt = $"Please answer Yes ({yesResponse}) or No ({noResponse}): ";

        bool success = false;
        uint attempt = 0;
        bool quit = false;
        response = false;

        do
        {
            if (maxAttempts > 0) // if user has a limited number of attempts
            {
                attempt++;
                WriteRetryPrompt(attempt, maxAttempts);
            }

            Console.Write(prompt);
            string userInput = Console.ReadLine();

            if (userInput.ToUpper() == yesResponse.ToUpper() || userInput.ToUpper() == noResponse.ToUpper())
            {
                success = true;
                response = userInput.ToUpper() == yesResponse.ToUpper();
            }
            else
            {
                Console.WriteLine($"Invalid input.  Please enter {yesResponse} (Yes) or {noResponse} (No).");
            }

            // quit when they've selected a menu option like we've asked
            // OR they've exceeded the maximum number of allowed attempts
            quit = success || attempt >= maxAttempts;
            if (!quit) Console.WriteLine();
        } while (!quit);

        return success;
    }

    public static bool TryPrompt4MenuItem<T>(string prompt, List<KeyValuePair<T, string>> menu, out T menuSelection, uint maxAttempts = 0)
    {
        if (string.IsNullOrWhiteSpace(prompt))
            prompt = "Please select one of the following options:";

        bool success = false;
        uint attempt = 0;
        bool quit = false;
        menuSelection = default;

        do
        {
            if (maxAttempts > 0) // if user has a limited number of attempts
            {
                attempt++;
                WriteRetryPrompt(attempt, maxAttempts);
            }

            Console.WriteLine(prompt);

            // this is the menu
            foreach (var menuItem in menu)
            {
                Console.WriteLine($"\t{menuItem.Key.ToString()}: {menuItem.Value}");
            }
            Console.Write("Selection: ");
            string userSelection = Console.ReadLine();

            if (menu.Any(mi => mi.Key.ToString().ToUpper() == userSelection.ToUpper()))
            {
                success = true;
                menuSelection = menu.FirstOrDefault(mi => mi.Key.ToString() == userSelection.ToUpper()).Key;
            }
            else
                Console.WriteLine($"{userSelection} is not an available option");

            // quit when they've selected a menu option like we've asked
            // OR they've exceeded the maximum number of allowed attempts
            quit = success || attempt >= maxAttempts;
            if (!quit) Console.WriteLine();
        } while (!quit);

        return success;
    }

    private static void WriteRetryPrompt(uint attempt, uint maxAttempts)
    {
        if (maxAttempts > 0 && attempt <= maxAttempts)
        {
            if (maxAttempts == 1)
                Console.WriteLine("You only get one try.");
            else
            {
                if (maxAttempts - attempt == 0)
                    Console.WriteLine("This is your last try.");
                else
                    Console.WriteLine($"You have {maxAttempts - attempt + 1} attempts remaining.");
            }
        }
    }

    //Pause program, wait for user to press spacebar to continue
    public static void Wait(string text)
    {
        Console.WriteLine($"Press the spacebar to {text}.");

        while (true)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                return;
        }
    }

    //Test user input for validity
    public static bool IsIntegerGreaterBetween(string value, int min, int max)
    {
        if (int.TryParse(value, out int n))
        {
            if (n > min && n < max)
                return true;
            else
            {
                Console.Write($"\nSelection must be greater than {min}, but less than {max}\n" +
                            $"Enter a number between {min} & {max}: "); //loop continues

                return false;
            }
        }
        else
        {
            Console.Write($"\n{value} is not an integer.\n" +
                                "Please enter a whole number: ");
            return false;
        }
    }
}