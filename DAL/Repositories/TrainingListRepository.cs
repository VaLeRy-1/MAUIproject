using DAL.EF;
using DAL.Entities;

namespace DAL.Repositories
{
    public class TrainingListRepository
    {
        private readonly FitnessContext context;

        public TrainingListRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<TrainingList> GetAll()
        {
            return context.TrainingsLists.ToList();
        }

        public TrainingList GetById(int listID)
        {
            return context.TrainingsLists.Find(listID);
        }

        public void Insert(TrainingList list)
        {
            context.TrainingsLists.Add(list);
        }

        public void Update(TrainingList list)
        {
        }

        public void Delete(int listID)
        {
            TrainingList list = context.TrainingsLists.Find(listID);

            if (list != null)
            {
                context.TrainingsLists.Remove(list);
            }
        }
    }
}