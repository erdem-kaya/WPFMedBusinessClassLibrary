using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Business.Services;

public class UserService(IFileService fileService, List<UserModel> users) : IUserService
{
    private readonly IFileService _fileService = fileService;
    private readonly List<UserModel> _users = users;

    public bool AddUser(UserRegistrationForm form)
    {
        var result = new List<ValidationResult>();
        var context = new ValidationContext(form);

        if (!Validator.TryValidateObject(form, context, result, true))
        {
            foreach (var validationError in result)
            {
                Console.WriteLine(validationError.ErrorMessage);
            }
            return false;
        }

        var user = UserFactory.CreateUser(form);

        if(_users.Any(u => u.Email == user.Email))
        {
            Console.WriteLine("User with this email already exists");
            return false;
        }

        _users.Add(user);
        _fileService.SaveUsers(_users);
        return true;
    }

    public bool DeleteUser(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;

        _users.Remove(user);
        _fileService.SaveUsers(_users);
        return true;
    }


    public IEnumerable<UserModel> GetUsers()
    {
        return _users;
    }

    public bool UpdateUser(UserModel user)
    {
        try
        {
            var value = _users.FirstOrDefault(u => u.Id == user.Id);
            if (value == null) return false;

            value.FirstName = user.FirstName;
            value.LastName = user.LastName;
            value.Email = user.Email;
            value.PhoneNumber = user.PhoneNumber;
            value.Address = user.Address;
            value.City = user.City;
            value.PostalCode = user.PostalCode;

            _fileService.SaveUsers(_users);
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
