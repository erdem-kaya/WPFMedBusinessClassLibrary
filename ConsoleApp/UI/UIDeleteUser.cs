using Business.Services;
using ConsoleApp.Dialogs;

namespace ConsoleApp.UI;

public class UIDeleteUser(UserService userService)
{
    private readonly UserService _userService = userService;


    public void DeleteUser()
    {
        Dialog.MenuHeader(" DELETE USER ");

        var userId = Dialog.Prompt("User Id");

        //Om userId inte är en giltig
        if (!Guid.TryParse(userId, out var id))
        {
            Console.WriteLine("Invalid user id");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var user = _userService.GetAllUsers().FirstOrDefault(user => user.Id == id);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        else
        {
            _userService.DeleteUser(user.Id);
            Console.WriteLine();
            Console.WriteLine("User deleted successfully");
        }



        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

    }
}