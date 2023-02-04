using DAL.EF;
using DAL.Entities;

namespace DAL.Repositories
{
    public class ExercisesListRepository
    {
        private readonly FitnessContext context;

        public ExercisesListRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<ExercisesList> GetAll()
        {
            return context.ExerciseLists.ToList();
        }

        public ExercisesList GetById(int listID)
        {
            return context.ExerciseLists.Find(listID);
        }

        public void Insert(ExercisesList list)
        {
            context.ExerciseLists.Add(list);
        }

        public void Update(ExercisesList list)
        {
        }

        public void Delete(int listID)
        {
            ExercisesList list = context.ExerciseLists.Find(listID);

            if (list != null)
            {
                context.ExerciseLists.Remove(list);
            }
        }
    }
}