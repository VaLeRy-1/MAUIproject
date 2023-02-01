using DAL.EF;
using DAL.Entities;

namespace DAL.Repositories
{
    public class PersonalActivitiesListRepository
    {
        private readonly FitnessContext context;

        public PersonalActivitiesListRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public PersonalActivitiesList GetById(int listID)
        {
            return context.Lists.Find(listID);
        }

        public void Insert(PersonalActivitiesList list)
        {
            context.Lists.Add(list);
        }

        public void Update(PersonalActivitiesList list)
        {
        }

        public void Delete(int listID)
        {
            PersonalActivitiesList list = context.Lists.Find(listID);

            if (list != null)
            {
                context.Lists.Remove(list);
            }
        }
    }
}