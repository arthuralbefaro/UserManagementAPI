namespace UserManagemenrtAPI.DTOs;

public record UserUpdateRequest(
    string? Name,
    string? Email,
    string? Department
);