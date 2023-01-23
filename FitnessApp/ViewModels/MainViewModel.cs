using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using FitnessApp.Models;

namespace FitnessApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

    public ObservableCollection<TrainingModel> Trainings { get; set; }
}
