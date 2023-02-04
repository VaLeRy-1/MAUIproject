using AutoMapper;
using BLL.DTO;
using BLL.Services;
using PL.Models;

namespace PL.Pages;

public partial class StartPage : ContentPage
{
    public List<TrainingGroup> Trainings { get; set; } = new List<TrainingGroup>();

    public StartPage()
	{
        InitializeComponent();

		WelcomeLabel.Text += CurrentUser.Name;

        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TrainingDTO, TrainingViewModel>()).CreateMapper();

        TrainingService trainingService = new TrainingService();
        List<TrainingDTO> trainingsDTO = trainingService.GetTrainings(CurrentUser.Name);
        List<TrainingViewModel> trainings = new List<TrainingViewModel>();

        foreach (var item in trainingsDTO)
        {
            trainings.Add(mapper.Map<TrainingDTO, TrainingViewModel>(item));
        }

        Trainings.Add(new TrainingGroup("Trainings", trainings));

        TrainingCollection.ItemsSource = Trainings;
    }

    private void GoToChangeTrainings(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChangeTrainingsPage());
    }
}