using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class GetTrainingService
    {
        UnitOfWork unit { get; set; }

        public GetTrainingService()
        {
            this.unit = new UnitOfWork();
        }

        public GetTrainingService(UnitOfWork unit)
        {
            this.unit = unit;
        }

        public IEnumerable<TrainingDTO> GetTraining()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Training, TrainingDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Training>, List<TrainingDTO>>(unit.trainings.GetAll());
        }
    }
}
