using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> users { get; }
        IRepository<BodyParameters> bodies { get; }
        IRepository<PersonalActivity> activities { get; }
        IRepository<PersonalInfo> infos { get; }
        IRepository<DifficultyLevel> difficulties { get; }
        IRepository<Exercises> exercises { get; }
        IRepository<Training> trainings { get; }

        void Save();
    }
}