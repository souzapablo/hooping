using Hooping.Api.Entities;

namespace Hooping.Api.Auth;

public interface IJwtProvider
{
    string Generate(User user);
}
