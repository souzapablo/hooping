using System.ComponentModel.DataAnnotations;

namespace Hooping.Common.Requests.User;
public record CreateUserRequest
{
    [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "A senha deve conter pelo menos oito caracteres, um maísculo, um minúsculo, um número e um caracter especial.")]
    public string Password { get; set; } = string.Empty;

    [Compare(nameof(Password), ErrorMessage = "As senhas não conferem.")]
    public string ConfirmPassword { get; set; } = string.Empty;
};