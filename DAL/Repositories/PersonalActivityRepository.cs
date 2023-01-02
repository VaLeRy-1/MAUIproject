using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PersonalActivityRepository : IRepository<PersonalActivity>
    {
        private readonly FitnessContext context;

        public PersonalActivityRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<PersonalActivity> GetAll()
        {
            return context.Personalactivities.ToList();
        }

        public PersonalActivity GetById(int activityID)
        {
            return context.Personalactivities.Find(activityID);
        }

        public void Insert(PersonalActivity activity)
        {
            context.Personalactivities.Add(activity);
        }

        public void Update(PersonalActivity activity)
        {
            PersonalActivity newActivity = context.Personalactivities.Find(activity.id);
            newActivity.steps = activity.steps;
            newActivity.calories = activity.calories;
            newActivity.water = activity.water;
        }

        public void Delete(int activityID)
        {
            PersonalActivity activity = context.Personalactivities.Find(activityID);

            if (activity != null)
            {
                context.Personalactivities.Remove(activity);
            }
        }
    }
}