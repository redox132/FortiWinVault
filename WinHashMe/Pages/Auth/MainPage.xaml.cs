using WinHashMe.Pages.Main;
using Windows.Security.Credentials;

namespace WinHashMe;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnNextAuthButtonClicked(object? sender, EventArgs e)
    {
#if WINDOWS
        bool isSupported = await KeyCredentialManager.IsSupportedAsync();
        if (!isSupported)
        {
            await DisplayAlertAsync("Error", "Windows Hello is not supported on your device", "OK");
            return;
        }

        KeyCredentialRetrievalResult result = await KeyCredentialManager.RequestCreateAsync("login", KeyCredentialCreationOption.ReplaceExisting);

        if (result.Status == KeyCredentialStatus.Success)
        {
            await Shell.Current.GoToAsync(nameof(VaultPage));
        }
        else
        {
            await DisplayAlertAsync("Error", "Failed to authenticate", "OK");
        }
#else
        // For Mac/other platforms, skip auth for now
        await Shell.Current.GoToAsync(nameof(VaultPage));
#endif
    }
}