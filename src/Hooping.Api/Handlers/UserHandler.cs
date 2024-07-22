using Hooping.Api.Data;
using Hooping.Api.Entities;
using Hooping.Common.Errors;
using Hooping.Common.Handlers;
using Hooping.Common.Requests.User;
using Hooping.Common.Responses;
using Microsoft.EntityFrameworkCore;
using Encrypt = BCrypt.Net.BCrypt;

namespace Hooping.Api.Handlers;

public class UserHandler(
    HoopingDbContext context) : IUserHandler
{
    public async Task<Result<long>> CreateAsync(CreateUserRequest request)
    {
        var userExists = await context.Users
            .AnyAsync(u => u.Email.Equals(request.Email.ToLower()));

        if (userExists)
            return Result.Failure<long>(UserErrors.EmailAlreadyRegistered);

        var passwordHash = Encrypt.HashPassword(request.Password);
        var newUser = new User(request.Email.ToLower(), passwordHash);

        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();

        return newUser.Id;
    }
}
