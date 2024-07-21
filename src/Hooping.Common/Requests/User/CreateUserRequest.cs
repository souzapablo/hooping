namespace Hooping.Common.Requests.User;
public record CreateUserRequest(
    string Email,
    string Password);