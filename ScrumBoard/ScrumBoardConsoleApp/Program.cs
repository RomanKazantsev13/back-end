namespace ScrumBoardConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        string? command = "";

        Controller.ShowCommands();
        while (command != "...")
        {
            command = Console.ReadLine();
            if (command == "Help")
            {
                Controller.ShowCommands();
                continue;
            }

            if (!Controller.HandleCommand(command))
            {
                Console.WriteLine(" > Unknown command");
            }
            Console.WriteLine();
        }
    }
}

