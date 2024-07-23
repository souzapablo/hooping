using Hooping.Common.Requests.User;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Hooping.Web.Pages.Identity;

public partial class RegisterPage : ComponentBase
{
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IUserHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public CreateUserRequest InputModel { get; set; } = new();
    public bool IsBusy { get; set; }


    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(InputModel);

            if (result.IsSuccess)
            {
                Snackbar.Add("Usuário criado com sucesso.", Severity.Success);
                NavigationManager.NavigateTo("/login");
            }
            else
                Snackbar.Add(result.Error?.Description, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

}
