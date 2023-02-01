using AutoMapper;
using BLL.DTO;
using BLL.Services;
using PL.Models;

namespace PL.Pages;

public partial class ActivityPage : ContentPage
{
    public ActivityPage()
    {
        InitializeComponent();

        DisplayActivity();
    }

    private void DisplayActivity()
    {
        ActivitiesService activitiesService = new ActivitiesService();

        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalActivityDTO, PersonalActivityViewModel>()).CreateMapper();

        PersonalActivityViewModel activity = mapper.Map<PersonalActivityDTO, PersonalActivityViewModel>(activitiesService.GetActivity(CurrentUser.Name));

        StepsLabel.Text = "Шаги: ";
        WaterLabel.Text = "Выпито воды: ";
        CaloriesLabel.Text = "Поглощено калорий: ";

        AddStepsEntry.Text = null;
        AddCaloriesEntry.Text = null;
        AddWaterEntry.Text = null;

        StepsLabel.Text += activity.Steps.ToString();
        WaterLabel.Text += activity.Water.ToString();
        CaloriesLabel.Text += activity.Calories.ToString();
    }

    private void UpdateCalories(object sender, EventArgs e)
    {
        int caloriesToAdd = 0;

        try
        {
            caloriesToAdd = int.Parse(AddCaloriesEntry.Text);
        }
        catch (Exception)
        {
            return;
        }

        ActivitiesService activitiesService = new ActivitiesService();

        PersonalActivityDTO activityDTO = new PersonalActivityDTO();

        activityDTO.Steps = int.Parse(StepsLabel.Text.Remove(0, 6));
        activityDTO.Water = int.Parse(WaterLabel.Text.Remove(0, 13));
        activityDTO.Calories = int.Parse(CaloriesLabel.Text.Remove(0, 19)) + caloriesToAdd;
        activityDTO.Date = DateTime.Today;

        activitiesService.UpdateAcitivity(CurrentUser.Name, activityDTO);

        DisplayActivity();
    }

    private void UpdateWater(object sender, EventArgs e)
    {
        int waterToAdd = 0;

        try
        {
            waterToAdd = int.Parse(AddWaterEntry.Text);
        }
        catch (Exception)
        {
            return;
        }

        ActivitiesService activitiesService = new ActivitiesService();

        PersonalActivityDTO activityDTO = new PersonalActivityDTO();

        activityDTO.Steps = int.Parse(StepsLabel.Text.Remove(0, 6));
        activityDTO.Water = int.Parse(WaterLabel.Text.Remove(0, 13)) + waterToAdd;
        activityDTO.Calories = int.Parse(CaloriesLabel.Text.Remove(0, 19));
        activityDTO.Date = DateTime.Today;

        activitiesService.UpdateAcitivity(CurrentUser.Name, activityDTO);

        DisplayActivity();
    }

    private void GoToStatistic(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StatisticsPage());
    }

    private void UpdateSteps(object sender, EventArgs e)
    {
        int stepsToAdd = 0;

        try
        {
            stepsToAdd = int.Parse(AddStepsEntry.Text);
        }
        catch (Exception)
        {
            return;
        }

        ActivitiesService activitiesService = new ActivitiesService();

        PersonalActivityDTO activityDTO = new PersonalActivityDTO();

        activityDTO.Steps = int.Parse(StepsLabel.Text.Remove(0, 6)) + stepsToAdd;
        activityDTO.Water = int.Parse(WaterLabel.Text.Remove(0, 13));
        activityDTO.Calories = int.Parse(CaloriesLabel.Text.Remove(0, 19));
        activityDTO.Date = DateTime.Today;

        activitiesService.UpdateAcitivity(CurrentUser.Name, activityDTO);

        DisplayActivity();
    }
}