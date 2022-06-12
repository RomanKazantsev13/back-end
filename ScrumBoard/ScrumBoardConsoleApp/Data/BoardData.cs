namespace ScrumBoardConsoleApp.Data;

public class BoardData
{
    public static Guid? GetId(string message)
    {
        String? str;
        Guid id;

        while (true)
        {
            Console.Write(message + " or exit: ");
            str = Console.ReadLine();

            if (str == "exit")
            {
                return null;
            }

            if (Guid.TryParse(str, out id))
            {
                return id;
            }

            Console.WriteLine(" > Invalid id value");
        }
    }
}
