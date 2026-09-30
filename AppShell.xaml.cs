namespace MagazijnApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registreer de routes voor navigatie
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

    }
}

