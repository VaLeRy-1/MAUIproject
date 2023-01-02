using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitnessContext context;
        private UserRepository userRepository;
        private BodyParameteresRepository bodyParameteresRepository;
        private PersonalActivityRepository personalActivityRepository;
        private PersonalInfoRepository personalInfoRepository;
        private bool isDisposed = false;

        public UnitOfWork()
        {
            context = new FitnessContext();
        }

        public IRepository<User> users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public IRepository<BodyParameters> bodies
        {
            get
            {
                if (bodyParameteresRepository == null)
                {
                    bodyParameteresRepository = new BodyParameteresRepository(context);
                }
                return bodyParameteresRepository;
            }
        }

        public IRepository<PersonalActivity> activities
        {
            get
            {
                if (personalActivityRepository == null)
                {
                    personalActivityRepository = new PersonalActivityRepository(context);
                }
                return personalActivityRepository;
            }
        }

        public IRepository<PersonalInfo> infos
        {
            get
            {
                if (personalInfoRepository == null)
                {
                    personalInfoRepository = new PersonalInfoRepository(context);
                }
                return personalInfoRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}