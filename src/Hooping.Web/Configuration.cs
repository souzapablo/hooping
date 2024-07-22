using MudBlazor.Utilities;
using MudBlazor;

namespace Hooping.Web;

public class Configuration
{
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Raleway", "sans-serif"]
            }
        },
        PaletteLight = new PaletteLight
        {
            Primary = new MudColor("#69C994"),
            PrimaryContrastText = new MudColor("#FFF5F5"),
            Error = new MudColor("#902124"),
            Background = Colors.Gray.Lighten4,
            AppbarBackground = new MudColor("#6EA283"),
            AppbarText = new MudColor("#FFF5F5"),
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.White,
            DrawerBackground = new MudColor("#508366"),
            ActionDefault = new MudColor("#AAE3C1")
        },
        PaletteDark = new PaletteDark
        {
            Primary = new MudColor("#6EA283"),
            ActionDefault = new MudColor("#6EA283"),
            Black = new MudColor("#6EA283")
        }
    };
}
