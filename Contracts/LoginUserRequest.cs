namespace Contracts;

public record LoginUserRequest(
    string Username,
    string Password);