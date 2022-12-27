using AutoMapper;
using BLL.DTO;
using BLL.Services;
using FitnessTemp.Models;

namespace FitnessApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetUsersService usersService = new GetUsersService();

            IEnumerable<UserDTO> usersDTO = usersService.GetUsers();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();

            List<UserViewModel> users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(usersDTO);

            foreach (var item in users)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}