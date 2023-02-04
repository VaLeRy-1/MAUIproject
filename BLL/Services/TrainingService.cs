using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class TrainingService
    {
        UnitOfWork Unit { get; set; }
        int trainingListId;

        public TrainingService()
        {
            this.Unit = new UnitOfWork();
        }

        public List<TrainingDTO> GetTrainings(string name)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (User user in users)
            {
                if (user.name == name)
                {
                    this.trainingListId = user.trainingListId;
                    continue;
                }
            }

            List<Training> trainings = (List<Training>)Unit.trainings.GetAll();
            List<TrainingDTO> userTrainings = new List<TrainingDTO>();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Training, TrainingDTO>()).CreateMapper();

            foreach (Training training in trainings)
            {
                if (training.trainingListId == this.trainingListId)
                {
                    TrainingDTO trainingDTO = mapper.Map<Training, TrainingDTO>(training);
                    trainingDTO.Difficulty = GetDifficultyLevel(training.difficultyLevelId);
                    userTrainings.Add(trainingDTO);
                }
            }

            return userTrainings;
        }

        public List<TrainingDTO> GetUnusedTrainings(string name)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (User user in users)
            {
                if (user.name == name)
                {
                    this.trainingListId = user.trainingListId;
                    continue;
                }
            }

            List<Training> trainings = (List<Training>)Unit.trainings.GetAll();
            List<TrainingDTO> unusedTrainings = new List<TrainingDTO>();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Training, TrainingDTO>()).CreateMapper();

            foreach (Training training in trainings)
            {
                if (training.trainingListId == 0)
                {
                    TrainingDTO trainingDTO = mapper.Map<Training, TrainingDTO>(training);
                    trainingDTO.Difficulty = GetDifficultyLevel(training.difficultyLevelId);
                    unusedTrainings.Add(trainingDTO);
                }
            }

            return unusedTrainings;
        }

        public void AddTraining(string userName, string trainingName)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (User user in users)
            {
                if (user.name == userName)
                {
                    this.trainingListId = user.trainingListId;
                    continue;
                }
            }

            List<Training> trainings = (List<Training>)Unit.trainings.GetAll();

            foreach (Training training in trainings)
            {
                if (training.name == trainingName)
                {
                    training.trainingListId = this.trainingListId;
                    Unit.trainings.Update(training);
                    Unit.Save();
                }
            }

        }

        public void DeleteTraining(string trainingName)
        {
            
            List<Training> trainings = (List<Training>)Unit.trainings.GetAll();

            foreach (Training training in trainings)
            {
                if (training.name == trainingName)
                {
                    training.trainingListId = 0;
                    Unit.trainings.Update(training);
                    Unit.Save();
                }
            }

        }

        public string GetDifficultyLevel(int difficultyId)
        {
            DifficultyLevel difficulty = Unit.difficulties.GetById(difficultyId);

            return difficulty.name;
        }
    }
}