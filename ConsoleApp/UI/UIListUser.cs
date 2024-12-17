using Business.Services;
using ConsoleApp.Dialogs;

namespace ConsoleApp.UI;

public class UIListUser(UserService userService)
{
    private readonly UserService _userService = userService;

    public void ListUsers()
    {
        Dialog.MenuHeader(" LIST USERS ");

        var users = _userService.GetAllUsers();

        if (!users.Any())
        {
            Console.WriteLine("No users found");
        }
        else
        {
            foreach (var user in users)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"First Name: {user.FirstName}");
                Console.WriteLine($"Last Name: {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Phone Number: {user.PhoneNumber}");
                Console.WriteLine($"Address: {user.Address}");
                Console.WriteLine($"Postal Code: {user.PostalCode}");
                Console.WriteLine($"City: {user.City}");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

    }

}