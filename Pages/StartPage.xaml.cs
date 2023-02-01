using PL.Models;

namespace PL.Pages;

public partial class StartPage : ContentPage
{
    public List<TrainingGroup> Trainings { get; set; } = new List<TrainingGroup>();

    public StartPage()
	{
        InitializeComponent();

		WelcomeLabel.Text += CurrentUser.Name;

        Trainings.Add(new TrainingGroup("Trainings", new List<TrainingViewModel>
        {
            new TrainingViewModel
            {
                Name = "�����",
                Time = "20",
                Difficulty = "������",
                Quantity = "10"
            },
            new TrainingViewModel
            {
                Name = "����",
                Time = "30",
                Difficulty = "������",
                Quantity = "7"
            }
        }));

        TrainingCollection.ItemsSource = Trainings;
    }
}