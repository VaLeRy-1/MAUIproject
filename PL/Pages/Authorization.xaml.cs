﻿using AutoMapper;
using BLL.DTO;
using BLL.Services;
using PL.Models;

namespace PL;

public partial class MainPage : ContentPage
{
	private List<Entry> registrationEntries;
    private List<Entry> loginEntries;

    public MainPage()
	{
		InitializeComponent();

		registrationEntries = new List<Entry> { RegistrationEntry, PasswordRegistrationEntry, PasswordRepeatEntry };
        loginEntries = new List<Entry> { LoginEntry, PasswordLoginEntry };
    }

    private async void Registration(object sender, EventArgs e)
    {

        ErrorLabel.Text = "";

        foreach (var item in registrationEntries)
		{
			if (item.Text == "" || item.Text == null)
			{
                ErrorLabel.Text = "Не все поля заполнены";
                await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
                await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
				return;
			}
		}

		if (PasswordRegistrationEntry.Text != PasswordRepeatEntry.Text)
		{
            ErrorLabel.Text = "Пароли не совпадают";
            await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
            await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
            return;
        }

		UserViewModel newUser = new UserViewModel();
		newUser.Name = RegistrationEntry.Text;

        newUser.Age = int.Parse(AgeEntry.Text);

        newUser.Password = PasswordRepeatEntry.Text;

		AuthorizationService authorization = new AuthorizationService();

        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>()).CreateMapper();

		if(!authorization.Register(mapper.Map<UserViewModel, UserDTO>(newUser)))
        {
            ErrorLabel.Text = "Пользователь под таким именем уже существует";
            await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
            await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
        }
        else
        {
            CurrentUser.Name = newUser.Name;
            CurrentUser.Age = newUser.Age;
            App.Current.MainPage = new NavigationPage(new TabPage());
        }
    }

    private async void Login(object sender, EventArgs e)
	{
        ErrorLabel.Text = "";

        foreach (var item in loginEntries)
        {
            if (item.Text == "" || item.Text == null)
            {
                ErrorLabel.Text = "Не все поля заполнены";
                await ErrorLabel.ScaleTo(1.1, 80, Easing.Linear);
                await ErrorLabel.ScaleTo(1, 80, Easing.Linear);
                return;
            }
        }

        AuthorizationService authorization = new AuthorizationService();

        (bool, string, int) result = authorization.IsLogin(LoginEntry.Text, PasswordLoginEntry.Text);

        if (result.Item1)
        {
            CurrentUser.Name = loginEntries[0].Text;
            CurrentUser.Age = result.Item3;
            App.Current.MainPage = new NavigationPage(new TabPage());
        }
        else
        {
            ErrorLabel.Text = result.Item2;
        }

        //CurrentUser.Name = "Дима";
        //App.Current.MainPage = new NavigationPage(new TabPage());
    }

    private void ChangeMenu(object sender, EventArgs e)
    {
		ErrorLabel.Text = "";

		if (LoginMenu.IsVisible)
		{
			LoginMenu.IsVisible = false;
			RegistrationMenu.IsVisible = true;
            ChangeButton.Text = "Вход";

        }
        else
		{
            LoginMenu.IsVisible = true;
            RegistrationMenu.IsVisible = false;
            ChangeButton.Text = "Регистрация";
        }

    }
}