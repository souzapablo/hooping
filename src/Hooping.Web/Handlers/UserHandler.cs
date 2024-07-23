using Hooping.Common.Requests.User;
using Hooping.Common.Responses;

namespace Hooping.Web.Handlers;

public class UserHandler : IUserHandler
{
    public Task<Result<long>> CreateAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }
}
