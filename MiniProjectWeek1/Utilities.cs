using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectWeek1
{
    internal class Utilities
    {
        public static int ReadInteger(string prompt, int min, int max)
        {
            int result = 0;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result) || (result < min || result > max))
            {
                Console.WriteLine("That is not a valid number. Please try again...");
                Console.Write(prompt);
            }

            return result;
        }
        public static void ReadString(string prompt, ref string? value)
        {
            Console.Write(prompt);
            value = Console.ReadLine();
            while (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("The response can not be blank...");
                Console.Write(prompt);
                value = Console.ReadLine();
            }
        }
        public static void ReadChoice(string prompt, string[] options, out int selection)
        {
            selection = 0;
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            selection = ReadInteger(prompt, 1, options.Length);
        }
        public static void ShowStats(Player p)
        {
            Console.WriteLine($"Name: {p.Name} XP: {p.XP}\nHP: {p.Health} Attack: {p.Attack}");
        }
    }
}
