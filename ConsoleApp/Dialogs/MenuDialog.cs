using ConsoleApp.UI;

namespace ConsoleApp.Dialogs;

public class MenuDialog(UICreateUser uiCreateUser, UIListUser uiListUser, UIUpdateUser uiUpdateUser, UIDeleteUser uiDeleteUser)
{
    private readonly UICreateUser _uiCreateUser = uiCreateUser;
    private readonly UIListUser _uiListUser = uiListUser;
    private readonly UIUpdateUser _uiUpdateUser = uiUpdateUser;
    private readonly UIDeleteUser _uiDeleteUser = uiDeleteUser;

    public void MenuOptions()
    {


        while (true)
        {
            Dialog.MenuHeader("Main Menu");
            Console.WriteLine();
            Console.WriteLine("1. List all users");
            Console.WriteLine("2. Add new user");
            Console.WriteLine("3. Update user");
            Console.WriteLine("4. Delete user");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();
            var choice = Dialog.Prompt("Enter your choice");
            switch (choice)
            {
                case "1":
                    Console.WriteLine("List all users");
                    _uiListUser.ListUsers();
                    break;
                case "2":
                    _uiCreateUser.CreateUser();
                    break;
                case "3":
                    _uiUpdateUser.UpdateUser();
                    break;
                case "4":
                    _uiDeleteUser.DeleteUser();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }


    }
}