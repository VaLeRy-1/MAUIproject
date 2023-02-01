using AutoMapper;
using BLL.DTO;
using BLL.Services;
using PL.Models;
using System.Diagnostics;

namespace PL.Pages;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
	}

    private void ShowStatistic(object sender, EventArgs e)
    {
		DateTime date = ChosenDate.Date;

		ActivitiesService service = new ActivitiesService();
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalActivityDTO, PersonalActivityViewModel>()).CreateMapper();

		PersonalActivityViewModel activityViewModel = mapper.Map<PersonalActivityDTO, PersonalActivityViewModel>(service.GetActivity(CurrentUser.Name, date));

        StepsLabel.Text = "����: ";
        WaterLabel.Text = "������ ����: ";
        CaloriesLabel.Text = "��������� �������: ";

        if (activityViewModel == null)
        {
            StepsLabel.Text += "��� ������";
            WaterLabel.Text += "��� ������";
            CaloriesLabel.Text += "��� ������";
            return;
        }

        StepsLabel.Text += activityViewModel.Steps.ToString();
        WaterLabel.Text += activityViewModel.Water.ToString();
        CaloriesLabel.Text += activityViewModel.Calories.ToString();
    }
}