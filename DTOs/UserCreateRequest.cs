namespace UserManagemenrtAPI.DTOs;

public record UserCreateRequest(
    string? Name,
    string? Email,
    string? Department
);