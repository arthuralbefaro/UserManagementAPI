using System.Text.RegularExpressions;
using UserManagemenrtAPI.DTOs;
using UserManagemenrtAPI.Models;

namespace UserManagemenrtAPI.Services;

public class UserService
{
    private readonly List<User> _users =
    [
        new User
        {
            Id = 1,
            Name = "Arthur Albefaro",
            Email = "arthur.albefaro@techhive.com",
            Department = "IT",
            CreatedAt = DateTime.UtcNow    
        },
        new User
        {
            Id = 2,
            Name = "Maria Fernanda",
            Email = "maria.fernanda@techhive.com",
            Department = "HR",
            CreatedAt = DateTime.UtcNow
        }
    ];

    private int _nextId = 3;

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public User Create(UserCreateRequest request)
    {
        var user = new User
        {
            Id = _nextId++,
            Name = request.Name!.Trim(),
            Email = request.Email!.Trim(),
            Department = request.Department!.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        _users.Add(user);

        return user;
    }

    public User? Update(int id, UserUpdateRequest request)
    {
        var user = GetById(id);

        if (user is null)
        {
            return null;
        }

        user.Name = request.Name!.Trim();
        user.Email = request.Email!.Trim();
        user.Department = request.Department!.Trim();
        user.UpdatedAt = DateTime.UtcNow;

        return user;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);

        if (user is null)
        {
            return false;
        }

        _users.Remove(user);

        return true;
    }

    public static string? ValidateUserData(string? name, string? email, string? department)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Name is required.";
        }

        if (name.Trim().Length < 2)
        {
            return "Name must have at least 2 characters";
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            return "Email is required";
        }
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            return "Email format is invalid.";
        }

        if (string.IsNullOrWhiteSpace(department))
        {
            return "Department is required.";
        }

        return null;
    }
}