using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PersonalInfoRepository : IRepository<PersonalInfo>
    {
        private readonly FitnessContext context;

        public PersonalInfoRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<PersonalInfo> GetAll()
        {
            return context.Personalinfos.ToList();
        }

        public PersonalInfo GetById(int infoID)
        {
            return context.Personalinfos.Find(infoID);
        }

        public void Insert(PersonalInfo info)
        {
            context.Personalinfos.Add(info);
        }

        public void Update(PersonalInfo info)
        {
            PersonalInfo newInfo = context.Personalinfos.Find(info.id);
            newInfo.email = info.email;
            newInfo.phoneNumber = info.phoneNumber;
        }

        public void Delete(int infoID)
        {
            PersonalInfo info = context.Personalinfos.Find(infoID);

            if (info != null)
            {
                context.Personalinfos.Remove(info);
            }
        }
    }
}