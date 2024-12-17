using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    IEnumerable<UserModel> GetAllUsers();
    bool AddUser(UserRegistrationForm form);
    bool UpdateUser(UserModel user);
    bool DeleteUser(Guid id);
}
