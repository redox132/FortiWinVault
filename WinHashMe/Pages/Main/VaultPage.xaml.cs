using System.Collections.ObjectModel;
using WinHashMe.Models;
using WinHashMe.Pages.Auth;

namespace WinHashMe.Pages.Main;

public partial class VaultPage : ContentPage
{
    public ObservableCollection<VaultItem> VaultItems { get; set; }

    public VaultPage()
    {
        InitializeComponent();

        VaultItems = new ObservableCollection<VaultItem>();
        BindingContext = this;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddPasswordPage(VaultItems));
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var item = (VaultItem)button.CommandParameter;

        // Open the AddPasswordPage modal but pre-fill fields
        await Navigation.PushModalAsync(new EditVaultPage(item));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;                 
        var itemToDelete = (VaultItem)button.CommandParameter; 

        bool confirm = await DisplayAlertAsync("Delete", $"Delete {itemToDelete.Website}?", "Yes", "No");
        if (confirm)
        {
            VaultItems.Remove(itemToDelete);        
        }
    }
}