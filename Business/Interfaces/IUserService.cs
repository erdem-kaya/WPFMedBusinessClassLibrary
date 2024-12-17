using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    IEnumerable<UserModel> GetUsers();
    bool AddUser(UserRegistrationForm form);
    bool UpdateUser(UserModel user);
    bool DeleteUser(Guid id);
}
