namespace UserManagemenrtAPI.Middleware;

public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public TokenAuthenticationMiddleware(
        RequestDelegate next,
        IConfiguration configuration
    )
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api/users"))
        {
            var authorizationHeader = context.Request.Headers.Authorization.ToString();
            var expectedToken = _configuration["ApiSettings:Token"];

            if (string.IsNullOrWhiteSpace(authorizationHeader) || authorizationHeader != $"Bearer {expectedToken}")
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Unauthorized. Invalid or missing token."
                });

                return;
            }
        }

        await _next(context);
    }
}