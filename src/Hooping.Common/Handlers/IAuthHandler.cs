using Hooping.Common.Requests.Auth;
using Hooping.Common.Responses;
using Hooping.Common.Responses.Auth;

namespace Hooping.Common.Handlers;
public interface IAuthHandler
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);
}
