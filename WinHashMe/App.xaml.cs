using Microsoft.Extensions.DependencyInjection;
using WinHashMe.Pages.Main;

namespace WinHashMe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VaultPage), typeof(VaultPage));
            Routing.RegisterRoute(nameof(EditVaultPage), typeof(EditVaultPage));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}