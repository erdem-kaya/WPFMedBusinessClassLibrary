namespace ConsoleApp.Dialogs;

public class Dialog
{
    public static void MenuHeader(string header)
    {
        Console.Clear();
        Console.WriteLine($"----------- {header.ToUpper()} ----------- ");
        Console.WriteLine();
    }

    public static string Prompt(string message)
    {
        Console.Write($"{message}: ");
        return Console.ReadLine()!;
    }
}
