using Business.Interfaces;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonOptions;

    public FileService(string directoryPath = "Data", string fileName = "users.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public void SaveUsers(List<UserModel> users)
    {
        try
        {

            if (!Directory.Exists(_directoryPath))
            {

                Directory.CreateDirectory(_directoryPath);
            }

            var json = JsonSerializer.Serialize(users, _jsonOptions);


            File.WriteAllText(_filePath, json);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving users: {ex.Message}");
        }
    }
    public List<UserModel> ReadUsers()
    {
        try
        {
            if (!File.Exists(_filePath))
                return [];

            var json = File.ReadAllText(_filePath);
            var users = JsonSerializer.Deserialize<List<UserModel>>(json, _jsonOptions);

            return users ?? [];

        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            return [];
        }
    }
}
