namespace PL.Models
{
    public class TrainingGroup : List<TrainingViewModel>
    {
        public string Name { get; set; }

        public TrainingGroup(string name, List<TrainingViewModel> trainings) : base(trainings)
        {
            this.Name = name;
        }
    }
}