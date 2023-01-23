using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FitnessApp.Models
{
    public class TrainingModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public int Id;
        public string Name;
        public int[] Exercises;

        public string name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("name");
            }
        }

        public int[] exercises
        {
            get { return Exercises; }
            set
            {
                Exercises = value;
                OnPropertyChanged("exercises");
            }
        }       
    }
}
