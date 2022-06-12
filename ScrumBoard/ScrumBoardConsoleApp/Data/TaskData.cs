namespace ScrumBoardConsoleApp.Data;

using ScrumBoard;

public class TaskData
{
    public static string GetTitle()
    {
        string? title = "";

        while (true)
        {
            Console.Write("Enter a new task title: ");
            title = Console.ReadLine();
            Console.WriteLine();

            if (title != "" && title != null)
            {
                break;
            }

            Console.WriteLine(" > Invalid title value");
        }

        return title;
    }

    public static string GetDescription()
    {
        string? description = "";

        while (true)
        {
            Console.Write("Enter a new task description: ");
            description = Console.ReadLine();
            Console.WriteLine();

            if (description != "" && description != null)
            {
                break;
            }

            Console.WriteLine(" > Invalid description value");
        }

        return description;
    }

    public static ITask.TaskPriority GetPriority()
    {
        int priority = 0;

        while (true)
        {
            Console.Write("Enter the priority (1, 2, .., 5): ");

            if (Int32.TryParse(Console.ReadLine(), out priority) && 1 <= priority && priority <= 5)
            {
                break;
            }

            Console.WriteLine(" > Invalid priority value");
        }

        return (ITask.TaskPriority)priority;
    }
}
