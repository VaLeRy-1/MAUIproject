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
                Name = "Пресс",
                Time = "20",
                Difficulty = "Сложно",
                Quantity = "10"
            },
            new TrainingViewModel
            {
                Name = "Ноги",
                Time = "30",
                Difficulty = "Средне",
                Quantity = "7"
            }
        }));

        TrainingCollection.ItemsSource = Trainings;
    }
}