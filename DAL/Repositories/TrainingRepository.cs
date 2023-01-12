using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TrainingRepository : IRepository<Training>
    {
        private readonly FitnessContext context;

        public TrainingRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<Training> GetAll()
        {
            return context.Trainings.ToList();
        }

        public Training GetById(int trainingID)
        {
            return context.Trainings.Find(trainingID);
        }

        public void Insert(Training training)
        {
            context.Trainings.Add(training);
        }

        public void Update(Training training)
        {
            Training newTraining = context.Trainings.Find(training.id);
            newTraining.name = training.name;
        }

        public void Delete(int trainingID)
        {
            Training training = context.Trainings.Find(trainingID);

            if (training != null)
            {
                context.Trainings.Remove(training);
            }
        }
    }
}