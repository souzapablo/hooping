namespace Hooping.Api.Entities;

public class User(
    string email,
    string passwordHash) : Entity
{
    public string Email { get; private set; } = email;
    public string PasswordHash { get; private set; } = passwordHash;
}
