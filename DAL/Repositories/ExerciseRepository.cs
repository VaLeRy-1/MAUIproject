using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ExerciseRepository : IRepository<Exercises>
    {
        private readonly FitnessContext context;

        public ExerciseRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<Exercises> GetAll()
        {
            return context.Exercises.ToList();
        }

        public Exercises GetById(int exerciseID)
        {
            return context.Exercises.Find(exerciseID);
        }

        public void Insert(Exercises exercise)
        {
            context.Exercises.Add(exercise);
        }

        public void Update(Exercises exercise)
        {
            Exercises newExercise = context.Exercises.Find(exercise.id);
            newExercise.name = exercise.name;
            newExercise.instruction = exercise.instruction;
        }

        public void Delete(int exerciseID)
        {
            Exercises exercise = context.Exercises.Find(exerciseID);

            if (exercise != null)
            {
                context.Exercises.Remove(exercise);
            }
        }
    }
}