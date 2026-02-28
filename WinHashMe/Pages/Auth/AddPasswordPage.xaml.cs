using System.Collections.ObjectModel;
using WinHashMe.Models;

namespace WinHashMe.Pages.Auth;

public partial class AddPasswordPage : ContentPage
{
    private readonly ObservableCollection<VaultItem> _vaultItems;

    public AddPasswordPage(ObservableCollection<VaultItem> vaultItems)
    {
        InitializeComponent();
        _vaultItems = vaultItems;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(WebsiteEntry.Text) ||
            string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlertAsync("Error", "All fields are required.", "OK");
            return;
        }

        _vaultItems.Add(new VaultItem
        {
            Website = WebsiteEntry.Text,
            Username = UsernameEntry.Text,
            Password = PasswordEntry.Text
        });

        await Navigation.PopModalAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}