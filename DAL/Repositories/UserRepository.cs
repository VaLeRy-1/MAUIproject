using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly FitnessContext context;

        public UserRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int userID)
        {
            return context.Users.Find(userID);
        }

        public void Insert(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Users.Find(user.id).name = user.name;
            context.Users.Find(user.id).age = user.age;
            context.Users.Find(user.id).activityId = user.activityId;
            context.Users.Find(user.id).infoId = user.infoId;
            context.Users.Find(user.id).bodyId = user.bodyId;
        }

        public void Delete(int userID)
        {
            User user = context.Users.Find(userID);

            if (user != null)
            {
                context.Users.Remove(user);
            }
        }
    }
}