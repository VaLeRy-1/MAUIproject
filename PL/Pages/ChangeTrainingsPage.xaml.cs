using AutoMapper;
using BLL.DTO;
using BLL.Services;
using PL.Models;
using System.Windows.Input;

namespace PL.Pages;

public partial class ChangeTrainingsPage : ContentPage
{
    public List<TrainingGroup> Trainings { get; set; }
    public List<TrainingGroup> UnusedTrainings { get; set; }

    public ChangeTrainingsPage()
	{
		InitializeComponent();

        ShowTrainings();
    }

    private void ShowTrainings()
    {
        Trainings = new List<TrainingGroup>();
        UnusedTrainings = new List<TrainingGroup>();

        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TrainingDTO, TrainingViewModel>()).CreateMapper();

        TrainingService trainingService = new TrainingService();

        List<TrainingDTO> trainingsDTO = trainingService.GetTrainings(CurrentUser.Name);
        List<TrainingDTO> unusedTrainingsDTO = trainingService.GetUnusedTrainings(CurrentUser.Name);

        List<TrainingViewModel> trainings = new List<TrainingViewModel>();
        List<TrainingViewModel> unusedTrainings = new List<TrainingViewModel>();

        foreach (var item in trainingsDTO)
        {
            trainings.Add(mapper.Map<TrainingDTO, TrainingViewModel>(item));
        }

        foreach (var item in unusedTrainingsDTO)
        {
            unusedTrainings.Add(mapper.Map<TrainingDTO, TrainingViewModel>(item));
        }

        Trainings.Add(new TrainingGroup("Trainings", trainings));
        UnusedTrainings.Add(new TrainingGroup("Unused Trainings", unusedTrainings));

        TrainingCollection.ItemsSource = Trainings;
        AccessableTrainingCollection.ItemsSource = UnusedTrainings;
    }

    private void AddTraining(object sender, EventArgs e)
    {
        TrainingViewModel trainingToAdd = (TrainingViewModel)AccessableTrainingCollection.SelectedItem;

        TrainingService trainingService = new TrainingService();
        trainingService.AddTraining(CurrentUser.Name, trainingToAdd.Name);

        AccessableTrainingCollection.ItemsSource = null;
        TrainingCollection.ItemsSource = null;

        ShowTrainings();
    }

    private void DeleteTraining(object sender, EventArgs e)
    {
        TrainingViewModel trainingToDelete = (TrainingViewModel)TrainingCollection.SelectedItem;

        TrainingService trainingService = new TrainingService();
        trainingService.DeleteTraining(trainingToDelete.Name);

        TrainingCollection.ItemsSource = null;
        AccessableTrainingCollection.ItemsSource = null;

        ShowTrainings();
    }
}