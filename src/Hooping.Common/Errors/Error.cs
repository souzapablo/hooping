using Hooping.Common.Responses;

namespace Hooping.Common.Errors;
public sealed record Error(
    string Code,
    string? Description = null)
{
    public static readonly Error None = new(string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
    public static readonly Error ConditionNotMet = new("Error.ConditionNotMet", "The specified condition was not met.");

    public static implicit operator Result(Error error) => Result.Failure(error);

}