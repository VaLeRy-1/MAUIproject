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

        public IEnumerable<PersonalActivitiesList> GetAll()
        {
            return context.ActivitiesLists.ToList();
        }

        public PersonalActivitiesList GetById(int listID)
        {
            return context.ActivitiesLists.Find(listID);
        }

        public void Insert(PersonalActivitiesList list)
        {
            context.ActivitiesLists.Add(list);
        }

        public void Update(PersonalActivitiesList list)
        {
        }

        public void Delete(int listID)
        {
            PersonalActivitiesList list = context.ActivitiesLists.Find(listID);

            if (list != null)
            {
                context.ActivitiesLists.Remove(list);
            }
        }
    }
}