namespace Hooping.Common.Errors;
public class UserErrors
{
    public static readonly Error EmailAlreadyRegistered = new("User.RegisteredEmail", "E-mail already registered.");
}
