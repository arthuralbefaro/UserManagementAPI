using UserManagemenrtAPI.DTOs;
using UserManagemenrtAPI.Middleware;
using UserManagemenrtAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TokenAuthenticationMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        message = "User Management API is running.",
        project = "TechHive Solutions - User Management API"
    });
});

app.MapGet("/api/users", (UserService userService) =>
{
    var users = userService.GetAll();

    return Results.Ok(new
    {
        count = users.Count,
        users
    });
});

app.MapGet("/api/users/{id:int}", (int id, UserService userService) =>
{
    var user = userService.GetById(id);

    if (user is null)
    {
        return Results.NotFound(new
        {
            error = "User not found."
        });
    }

    return Results.Ok(user);
});

app.MapPost("/api/users", (UserCreateRequest request, UserService userService) =>
{
    var validationError = UserService.ValidateUserData(
        request.Name,
        request.Email,
        request.Department
    );

    if (validationError is not null)
    {
        return Results.BadRequest(new
        {
            error = validationError
        });
    }

    var user = userService.Create(request);

    return Results.Created($"/api/users/{user.Id}", user);
});

app.MapPut("/api/users/{id:int}", (int id, UserUpdateRequest request, UserService userService) =>
{
    var validationError = UserService.ValidateUserData(
        request.Name,
        request.Email,
        request.Department
    );

    if (validationError is not null)
    {
        return Results.BadRequest(new
        {
            error = validationError
        });
    }

    var updatedUser = userService.Update(id, request);

    if (updatedUser is null)
    {
        return Results.NotFound(new
        {
            error = "User not found."
        });
    }

    return Results.Ok(updatedUser);
});

app.MapDelete("/api/users/{id:int}", (int id, UserService userService) =>
{
    var deleted = userService.Delete(id);

    if (!deleted)
    {
        return Results.NotFound(new
        {
            error = "User not found."
        });
    }

    return Results.Ok(new
    {
        message = "User deleted successfully."
    });
});

app.Run();