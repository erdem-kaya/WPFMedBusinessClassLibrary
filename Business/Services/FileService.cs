using Business.Interfaces;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath = "Data", string fileName = "users.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public void DeleteUsers()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting users: {ex.Message}");
        }
    }

    public List<UserModel> ReadUsers()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return [];
            }
            var json = File.ReadAllText(_filePath);
            var users = JsonSerializer.Deserialize<List<UserModel>>(json, _jsonSerializerOptions);
            return users ?? new List<UserModel>();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading users: {ex.Message}");
            return [];
        }
    }

    public void SaveUsers(List<UserModel> users)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            var json = JsonSerializer.Serialize(users, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving users: {ex.Message}");
        }
    }

    // Jag är osäker på om denna metod behövs
    public void UpdateUsers(List<UserModel> users)
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            var json = JsonSerializer.Serialize(users, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating users: {ex.Message}");
        }
    }
}
