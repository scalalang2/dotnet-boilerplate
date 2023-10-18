namespace Contracts;

public record RegisterUserRequest(
    string Username,
    string Password);