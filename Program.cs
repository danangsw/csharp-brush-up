using System;
using OOP;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("🎬 Starting OOP Demonstrations...\n");
        Console.WriteLine("Press any key to continue...");
        while (true)
        {
            Console.WriteLine("1. Person Demo");
            Console.WriteLine("2. Inheritance Demo");
            Console.WriteLine("3. Interface Student Demo");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Type 'cls' to clear the console,");
            Console.Write("type '0' to close the program, \nor press '1 - 3' then ENTER to run the demos again:");
            string? input = Console.ReadLine();
            if (input != null && input.Trim().ToLower() == "0")
            {
                break;
            }
            switch (input)
            {
                case "1":
                    PersonDemo.Run();
                    break;
                case "2":
                    InheritanceDemo.Run();
                    break;
                case "3":
                    InterfaceStudentDemo.Run();
                    break;
                case "cls":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 3.");
                    break;
            }
        }
    }
}