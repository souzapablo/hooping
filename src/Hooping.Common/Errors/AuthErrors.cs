namespace Hooping.Common.Errors;
public class AuthErrors
{
    public static readonly Error InvalidCredentials = new("Auth.InvalidCredentials", "Invalid email or password.");
}
