using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class DifficultyLevelRepository : IRepository<DifficultyLevel>
    {
        private readonly FitnessContext context;

        public DifficultyLevelRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<DifficultyLevel> GetAll()
        {
            return context.DifficultyLevels.ToList();
        }

        public DifficultyLevel GetById(int difficultyID)
        {
            return context.DifficultyLevels.Find(difficultyID);
        }

        public void Insert(DifficultyLevel difficulty)
        {
            context.DifficultyLevels.Add(difficulty);
        }

        public void Update(DifficultyLevel difficulty)
        {
            DifficultyLevel newDifficulty = context.DifficultyLevels.Find(difficulty.id);
            newDifficulty.name = difficulty.name;
        }

        public void Delete(int difficultyID)
        {
            DifficultyLevel difficulty = context.DifficultyLevels.Find(difficultyID);

            if (difficulty != null)
            {
                context.DifficultyLevels.Remove(difficulty);
            }
        }
    }
}