using Business.Services;
using ConsoleApp.Dialogs;

namespace ConsoleApp.UI;

public class UIUpdateUser(UserService userService)
{
    private readonly UserService _userService = userService;

    public void UpdateUser()
    {
        Dialog.MenuHeader(" UPDATE USER ");

        var userId = Dialog.Prompt("User Id");

        //ChatGPT
        //Kolla om userId är en giltig
        if (!Guid.TryParse(userId, out var id))
        {
            Console.WriteLine("Invalid user id");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        // Hitta användaren med id
        var user = _userService.GetAllUsers().FirstOrDefault(user => user.Id == id);

        // Om användaren inte finns
        if (user == null)
        {
            Console.WriteLine("User not found");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        // Skriv ut användarinformation
        Console.WriteLine("If you don't want to change the first name, just press Enter");
        Console.WriteLine();
        var firstNameNewValue = Dialog.Prompt($"Enter new first name ( Current: {user.FirstName})");
        // Om användaren skriver in ett nytt värde
        if (!string.IsNullOrWhiteSpace(firstNameNewValue))
            user.FirstName = firstNameNewValue;


        // Skriv ut användarinformation
        Console.WriteLine("If you don't want to change the last name, just press Enter");
        Console.WriteLine();
        var lastNameNewValue = Dialog.Prompt($"Enter new last name ( Current: {user.LastName})");
        // Om användaren skriver in ett nytt värde
        if (!string.IsNullOrWhiteSpace(lastNameNewValue))
            user.LastName = lastNameNewValue;

        // Skriv ut användarinformation
        Console.WriteLine("If you don't want to change the email, just press Enter");
        Console.WriteLine();
        var emailNewValue = Dialog.Prompt($"Enter new email ( Current: {user.Email})");
        // Om användaren skriver in ett nytt värde
        if (!string.IsNullOrWhiteSpace(emailNewValue))
            user.Email = emailNewValue;

        // Skriv ut användarinformation
        Console.WriteLine("If you don't want to change the phone number, just press Enter");
        Console.WriteLine();
        var phoneNumberNewValue = Dialog.Prompt($"Enter new phone number ( Current: {user.PhoneNumber})");
        // Om användaren skriver in ett nytt värde
        if (!string.IsNullOrWhiteSpace(phoneNumberNewValue))
            user.PhoneNumber = phoneNumberNewValue;

        // Skriv ut användarinformation
        Console.WriteLine("If you don't want to change the address, just press Enter");
        Console.WriteLine();
        var addressNewValue = Dialog.Prompt($"Enter new address ( Current: {user.Address})");
        // Om användaren skriver in ett nytt värde
        if (!string.IsNullOrWhiteSpace(addressNewValue))
            user.Address = addressNewValue;


        // Skriv ut användarinformation
        Console.WriteLine("If you don't want to change the city, just press Enter");
        Console.WriteLine();
        var cityNewValue = Dialog.Prompt($"Enter new city ( Current: {user.City})");
        // Om användaren skriver in ett nytt värde
        if (!string.IsNullOrWhiteSpace(cityNewValue))
            user.City = cityNewValue;


        // Skriv ut användarinformation
        Console.WriteLine("If you don't want to change the postal code, just press Enter");
        Console.WriteLine();
        var postalCodeNewValue = Dialog.Prompt($"Enter new postal code ( Current: {user.PostalCode})");
        // Om användaren skriver in ett nytt värde
        if (!string.IsNullOrWhiteSpace(postalCodeNewValue))
            user.PostalCode = postalCodeNewValue;


        if (_userService.UpdateUser(user))
        {
            Console.WriteLine("User updated successfully");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Failed to update user");
            Console.ReadKey();
        }



    }
}
