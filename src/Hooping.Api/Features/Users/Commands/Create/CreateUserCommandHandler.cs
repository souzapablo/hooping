using Hooping.Api.Abstractions.Messaging;
using Hooping.Api.Data;
using Hooping.Api.Entities;
using Hooping.Common.Errors;
using Hooping.Common.Responses;
using Microsoft.EntityFrameworkCore;
using Encrypt = BCrypt.Net.BCrypt;

namespace Hooping.Api.Features.Users.Commands.Create;

public class CreateUserCommandHandler(
    HoopingDbContext context)
    : ICommandHandler<CreateUserCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await context.Users
            .AnyAsync(u => u.Email.Equals(request.Email.ToLower()), cancellationToken: cancellationToken);

        if (userExists)
            return Result.Failure<long>(UserErrors.EmailAlreadyRegistered);

        var passwordHash = Encrypt.HashPassword(request.Password);
        var newUser = new User(request.Email.ToLower(), passwordHash);

        await context.Users.AddAsync(newUser, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newUser.Id;
    }
}
