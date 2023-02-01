using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class UpdateInfoService
    {
        UnitOfWork Unit { get; set; }

        public UpdateInfoService()
        {
            this.Unit = new UnitOfWork();
        }

        public PersonalInfoDTO GetUserInfo(string name)
        {
            PersonalInfo info;
            int infoId = 0;

            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (User item in users)
            {

                if (item.name == name)
                {
                    infoId = item.infoId;

                    info = Unit.infos.GetById(infoId);

                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfo, PersonalInfoDTO>()).CreateMapper();

                    return mapper.Map<PersonalInfo, PersonalInfoDTO>(info);
                }

            }

            return null;
        }

        public void UpdateInfo(PersonalInfoDTO infoDTO, string name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfoDTO, PersonalInfo>()).CreateMapper();

            PersonalInfo newInfo = mapper.Map<PersonalInfoDTO, PersonalInfo>(infoDTO);

            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (User item in users)
            {

                if (item.name == name)
                {
                    newInfo.id = item.infoId;
                }

            }

            Unit.infos.Update(newInfo);
            Unit.Save();
        }
    }
}