using BLL.Services;
using PL.Models;

namespace PL.Pages;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage()
	{
		InitializeComponent();

		NameEntry.Text = CurrentUser.Name;
        AgeEntry.Text = CurrentUser.Age.ToString();
	}

    private async void Save(object sender, EventArgs e)
    {
        UpdateProfileService updateProfile = new UpdateProfileService();

        if ((PasswordEntry.Text != null && PasswordEntry.Text != "") ||
			(PasswordRepeatEntry.Text != null && PasswordRepeatEntry.Text != "") ||
            (NewPasswordEntry.Text != null && NewPasswordEntry.Text != ""))
		{

            if((PasswordEntry.Text == null || PasswordEntry.Text == "") ||
            (PasswordRepeatEntry.Text == null || PasswordRepeatEntry.Text == "") ||
            (NewPasswordEntry.Text == null || NewPasswordEntry.Text == ""))
            {
                ErrorLabel.Text = "Не все поля заполнены";
                await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
                await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
                return;
            }

            if (PasswordEntry.Text != PasswordRepeatEntry.Text)
            {
                ErrorLabel.Text = "Пароли не совпадают";
                await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
                await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
                return;
            }

            if (PasswordEntry.Text == NewPasswordEntry.Text)
            {
                ErrorLabel.Text = "Пароли не могут быть одинаковыми";
                await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
                await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
                return; 
            }

            (bool, string) result = updateProfile.UpdatePassword(CurrentUser.Name, PasswordEntry.Text, NewPasswordEntry.Text);

            if (result.Item1 == false)
            {
                ErrorLabel.Text = result.Item2;
                await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
                await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
                return;
            }
        }

        if (CurrentUser.Name != NameEntry.Text)
        {
            updateProfile.UpdateName(CurrentUser.Name, NameEntry.Text);

            CurrentUser.Name = NameEntry.Text;
        }

        if (CurrentUser.Age != int.Parse(AgeEntry.Text))
        {
            updateProfile.UpdateAge(CurrentUser.Name, int.Parse(AgeEntry.Text));

            CurrentUser.Age = int.Parse(AgeEntry.Text);
        }

        await Navigation.PopAsync();
    }
}