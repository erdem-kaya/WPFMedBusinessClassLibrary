
using ConsoleApp.Dialogs;

namespace ConsoleApp.Helpers;

public static class InputValidator
{
    //ChatGpt hjälpe mig med denna kod
    public static string InputValidateControl(string prompt, Func<string, string?> validate)
    {
        while (true)
        {
            var input = Dialog.Prompt(prompt);
            var inputError = validate(input);

            if (inputError == null)
                return input;

            Console.WriteLine(inputError);
        }
    }
}

