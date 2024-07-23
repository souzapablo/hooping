using System.ComponentModel.DataAnnotations;

namespace Hooping.Common.Requests.Auth;
public record LoginRequest
{
    [Required(ErrorMessage = "Endereço de e-mail é obrigatório.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Password { get; set; } = string.Empty;
}
