using Hooping.Api.Auth;
using Microsoft.Extensions.Options;

namespace Hooping.Api.OptionsSetup;

public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    private const string _sectionName = "Jwt";

    public void Configure(JwtOptions options)
    {
        configuration
            .GetSection(_sectionName)
            .Bind(options);
    }
}
