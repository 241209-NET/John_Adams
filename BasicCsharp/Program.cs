using System.ComponentModel;

namespace BasicCsharp;

class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        string? input = Console.ReadLine();
        Console.WriteLine(input?.Trim());
        
    }
}