using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class ActivitiesService
    {
        UnitOfWork Unit { get; set; }
        private int listId;

        public ActivitiesService()
        {
            this.Unit = new UnitOfWork();
        }

        public List<PersonalActivityDTO> GetActivities(string name)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (var item in users)
            {
                if (item.name == name)
                {
                    this.listId = item.activityListId;
                    continue;
                }
            }

            List<PersonalActivity> allActivities = (List<PersonalActivity>)Unit.activities.GetAll();

            List<PersonalActivityDTO> userActivities = new List<PersonalActivityDTO>();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalActivity, PersonalActivityDTO>()).CreateMapper();

            foreach (var item in allActivities)
            {

                if (item.listId == this.listId)
                {
                    userActivities.Add(mapper.Map<PersonalActivity, PersonalActivityDTO>(item));
                }

            }

            return userActivities;
        }

        public PersonalActivityDTO GetActivity(string name)
        {
            List<PersonalActivityDTO> activities = GetActivities(name);

            foreach (PersonalActivityDTO item in activities)
            {

                if (item.Date == DateTime.Today)
                {
                    return item;
                }

            }

            PersonalActivity newActivity = new PersonalActivity() { calories = 0, listId = this.listId, steps = 0, water = 0, date = DateTime.Today.ToUniversalTime() };

            Unit.activities.Insert(newActivity);
            Unit.Save();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalActivity, PersonalActivityDTO>()).CreateMapper();

            return mapper.Map<PersonalActivity, PersonalActivityDTO>(newActivity);
        }

        public PersonalActivityDTO GetActivity(string name, DateTime date)
        {
            List<PersonalActivityDTO> activities = GetActivities(name);

            foreach (PersonalActivityDTO item in activities)
            {

                if (item.Date == date)
                {
                    return item;
                }

            }

            return null;
        }

        public void UpdateAcitivity(string name, PersonalActivityDTO activityDTO)
        {
            List<PersonalActivityDTO> activities = GetActivities(name);
            int activityId = 0;

            foreach (PersonalActivityDTO item in activities)
            {
                if (item.Date == DateTime.Today)
                {
                    activityId = item.Id;
                }
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalActivityDTO, PersonalActivity>()).CreateMapper();
            PersonalActivity newActivity = mapper.Map<PersonalActivityDTO, PersonalActivity>(activityDTO);

            newActivity.id = activityId;

            Unit.activities.Update(newActivity);
            Unit.Save();
        }
    }
}