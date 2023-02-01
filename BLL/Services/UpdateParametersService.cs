using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class UpdateParametersService
    {
        UnitOfWork Unit { get; set; }

        public UpdateParametersService()
        {
            this.Unit = new UnitOfWork();
        }

        public BodyParametersDTO GetUserParameters(string name) 
        {
            BodyParameters parameters;
            int parametersId = 0;

            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (User item in users)
            {

                if (item.name == name)
                {
                    parametersId = item.bodyId;

                    parameters = Unit.bodies.GetById(parametersId);

                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BodyParameters, BodyParametersDTO>()).CreateMapper();

                    return mapper.Map<BodyParameters, BodyParametersDTO>(parameters);
                }

            }

            return null;
        }

        public void UpdateParameters(BodyParametersDTO parametersDTO, string name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BodyParametersDTO, BodyParameters>()).CreateMapper();

            BodyParameters newParameters = mapper.Map<BodyParametersDTO, BodyParameters>(parametersDTO);

            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (User item in users)
            {

                if (item.name == name)
                {
                    newParameters.id = item.bodyId;
                }

            }

            Unit.bodies.Update(newParameters);
            Unit.Save();
        }
    }
}