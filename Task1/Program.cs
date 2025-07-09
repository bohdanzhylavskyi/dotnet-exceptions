using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Your text: ");

                var inputText = Console.ReadLine();

                if (inputText == "end")
                {
                    Console.WriteLine("Bye bye");
                    break;
                }

                try
                {
                    PrintFirstCharacter(inputText);
                } catch (ArgumentException e)
                {
                    Console.WriteLine($"Invalid input: {e.Message}");
                }
            }
        }

        private static void PrintFirstCharacter(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text), "Text cannot be null.");
            }

            if (text.Length == 0)
            {
                throw new ArgumentException("Text should not be empty.");
            }

            var firstChar = text[0];

            if (firstChar == ' ')
            {
                throw new ArgumentException("Text cannot start with whitespace.");
            }

            Console.WriteLine($"First char: {firstChar}");
        }
    }
}