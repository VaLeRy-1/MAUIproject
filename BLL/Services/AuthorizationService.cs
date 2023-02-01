using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    public class AuthorizationService
    {
        UnitOfWork Unit { get; set; }

        public AuthorizationService() 
        { 
            this.Unit = new UnitOfWork();
        }

        public bool Register(UserDTO newUser)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (var item in users)
            {
                if (item.name == newUser.Name)
                {
                    return false;
                }
            }

            byte[] salt = RandomNumberGenerator.GetBytes(64);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(newUser.Password),
                salt, 1000, HashAlgorithmName.SHA1, 64);

            newUser.Salt = Convert.ToHexString(salt);
            newUser.Hash = Convert.ToHexString(hash);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            Unit.users.Insert(mapper.Map<UserDTO, User>(newUser));
            Unit.Save();

            return true;
        }

        public (bool, string, int) IsLogin(string name, string password)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (var item in users)
            {
                if (item.name == name)
                {
                    byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromHexString(item.salt), 1000, HashAlgorithmName.SHA1, 64);

                    if (hashToCompare.SequenceEqual(Convert.FromHexString(item.hash)))
                    {
                        return (true, "", item.age);
                    }
                    else
                    {
                        return (false, "Неверный пароль", 0);
                    }
                }
            }

            return (false, "Нет пользователя под таким именем", 0);
        }
    }
}