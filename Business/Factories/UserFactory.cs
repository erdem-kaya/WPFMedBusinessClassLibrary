using Business.Dtos;
using Business.Models;

namespace Business.Factories;

public static class UserFactory
{
    public static UserModel CreateUser(UserRegistrationForm form)
    {
        return new UserModel
        {
            Id = Guid.NewGuid(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            Address = form.Address,
            City = form.City,
            PostalCode = form.PostalCode
        };
    }
}
