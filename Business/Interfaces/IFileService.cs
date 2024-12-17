using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    IEnumerable<UserModel> ReadUsers();
    void SaveUsers(IEnumerable<UserModel> users);
    void DeleteUsers();
    void UpdateUsers(IEnumerable<UserModel> users);
}
