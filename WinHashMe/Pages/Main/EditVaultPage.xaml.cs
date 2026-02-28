using WinHashMe.Models;

namespace WinHashMe.Pages.Main;

public partial class EditVaultPage : ContentPage
{
    private readonly VaultItem _vaultItem;

    public EditVaultPage(VaultItem vaultItem)
    {
        InitializeComponent();
        _vaultItem = vaultItem;

        // Pre-fill entries with current data
        WebsiteEntry.Text = _vaultItem.Website;
        UsernameEntry.Text = _vaultItem.Username;
        PasswordEntry.Text = _vaultItem.Password;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Update the VaultItem directly
        _vaultItem.Website = WebsiteEntry.Text;
        _vaultItem.Username = UsernameEntry.Text;
        _vaultItem.Password = PasswordEntry.Text;

        await Navigation.PopModalAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}