using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class BodyParameteresRepository :  IRepository<BodyParameters>
    {
        private readonly FitnessContext context;

        public BodyParameteresRepository(FitnessContext context)
        {
            this.context = context;
        }

        public IEnumerable<BodyParameters> GetAll()
        {
            return context.Bodyparameters.ToList();
        }

        public BodyParameters GetById(int bodyID)
        {
            return context.Bodyparameters.Find(bodyID);
        }

        public void Insert(BodyParameters body)
        {
            context.Bodyparameters.Add(body);
        }

        public void Update(BodyParameters body)
        {
            BodyParameters newBody = context.Bodyparameters.Find(body.id);
            newBody.weight = body.weight;
            newBody.height = body.height;
            newBody.breast = body.breast;
            newBody.waist = body.waist;
            newBody.hips = body.hips;
        }

        public void Delete(int bodyID)
        {
            BodyParameters body = context.Bodyparameters.Find(bodyID);

            if (body != null)
            {
                context.Bodyparameters.Remove(body);
            }
        }
    }
}