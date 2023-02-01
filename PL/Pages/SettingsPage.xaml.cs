using PL.Models;

namespace PL.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        ProfileNameLabel.Text = CurrentUser.Name;
    }

    private void GoToEditProfilePage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditProfilePage());
    }

    private void GoToEditParametersPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditParametersPage());
    }

    private void GoToEditInfoPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditInfoPage());
    }

    private void Leave(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new MainPage());
    }
}