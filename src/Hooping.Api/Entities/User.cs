using Microsoft.AspNetCore.Identity;

namespace Hooping.Api.Entities;

public class User : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}
