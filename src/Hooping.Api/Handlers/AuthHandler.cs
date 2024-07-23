using Hooping.Api.Auth;
using Hooping.Api.Data;
using Hooping.Common.Errors;
using Hooping.Common.Handlers;
using Hooping.Common.Requests.Auth;
using Hooping.Common.Responses;
using Hooping.Common.Responses.Auth;
using Microsoft.EntityFrameworkCore;
using Encrypt = BCrypt.Net.BCrypt;

namespace Hooping.Api.Handlers;

public class AuthHandler(
    HoopingDbContext context,
    IJwtProvider jwtProvider) : IAuthHandler
{
    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var user = await context
            .Users
            .SingleOrDefaultAsync(x => x.Email == request.Email.ToLower());

        if (user is null)
            return Result.Failure<LoginResponse>(AuthErrors.InvalidCredentials);

        if (!Encrypt.Verify(request.Password, user.PasswordHash))
            return Result.Failure<LoginResponse>(AuthErrors.InvalidCredentials);

        var token = jwtProvider.Generate(user);

        return new LoginResponse(token);
    }
}
