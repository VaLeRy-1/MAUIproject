using FitnessApp.Models;

namespace FitnessApp;

public partial class MainPage : ContentPage
{
	public TrainingModel Training { get; private set; }

	public MainPage(TrainingModel training)
	{
		InitializeComponent();
		Training = training;
		BindingContext = Training;
    }

}

