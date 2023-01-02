using AutoMapper;
using BLL.DTO;
using DAL.Repositories;
using DAL.Entities;

namespace BLL.Services
{
    public class GetUsersService
    {
        UnitOfWork unit { get; set; }

        public GetUsersService()
        {
            this.unit = new UnitOfWork();
        }

        public GetUsersService(UnitOfWork unit)
        {
            this.unit = unit;
        }
        
        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<User>, List<UserDTO>>(unit.users.GetAll());
        }
    }
}