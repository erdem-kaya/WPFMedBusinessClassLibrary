using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    List<UserModel> ReadUsers();
    void SaveUsers(List<UserModel> users);
}