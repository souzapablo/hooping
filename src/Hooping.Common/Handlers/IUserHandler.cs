using Hooping.Common.Requests.User;
using Hooping.Common.Responses;

namespace Hooping.Common.Handlers;
public interface IUserHandler
{
    Task<Result<long>> CreateAsync(CreateUserRequest request);
}
