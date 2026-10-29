namespace Magazijn.Desktop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new MainPage())
		{
			Title = "Magazijn App",
			Width = 1280,
			Height = 850,
			MinimumWidth = 900,
			MinimumHeight = 650
		};
	}
}
