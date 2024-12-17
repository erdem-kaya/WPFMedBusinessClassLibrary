using Business.Dtos;
using Business.Services;
using ConsoleApp.Dialogs;
using ConsoleApp.Helpers;

namespace ConsoleApp.UI;

public class UICreateUser(UserService userService)
{
    private readonly UserService _userService = userService;

    public void CreateUser()
    {
        Dialog.MenuHeader(" CREATE USER ");

        var firstName = InputValidator.InputValidateControl("First Name", input =>
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return "First name must be at least 2 characters long";
            return null;
        });

        var lastName = InputValidator.InputValidateControl("Last Name", input =>
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return "Last name must be at least 2 characters long";
            return null;
        });

        var email = InputValidator.InputValidateControl("Email", input =>
        {
            if (string.IsNullOrWhiteSpace(input) || !input.Contains("@"))
                return "Invalid email format. Exempel name@domain.com";
            return null;
        });

        var phoneNumber = InputValidator.InputValidateControl("Phone Number", input =>
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Phone number is required";
            return null;
        });

        var address = InputValidator.InputValidateControl("Address", input =>
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return "Address must be at least 2 characters long";
            return null;
        });

        var city = InputValidator.InputValidateControl("City", input =>
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return "City must be at least 2 characters long";
            return null;
        });

        var postalCode = InputValidator.InputValidateControl("Postal Code", input =>
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 5)
                return "Postal code must be at least 5 characters long. Exempel: 12345 eller 123 45";
            return null;
        });


        try
        {
            var userRegistrationForm = new UserRegistrationForm
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                PostalCode = postalCode,
                City = city
            };
            if (_userService.AddUser(userRegistrationForm))
                Console.WriteLine("User created successfully");
            else
                Console.WriteLine("User not created");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}