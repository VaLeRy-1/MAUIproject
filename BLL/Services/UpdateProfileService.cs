using DAL.Entities;
using DAL.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    public class UpdateProfileService
    {
        UnitOfWork Unit { get; set; }

        public UpdateProfileService()
        {
            this.Unit = new UnitOfWork();
        }

        public void UpdateName(string oldName, string name) 
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (var item in users)
            {
                if (item.name == oldName)
                {
                    item.name = name;

                    Unit.users.Update(item);

                }
            }

            Unit.Save();
        }

        public void UpdateAge(string name, int newAge)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (var item in users)
            {
                if (item.name == name)
                {
                    item.age = newAge;

                    Unit.users.Update(item);

                }
            }

            Unit.Save();
        }

        public (bool, string) UpdatePassword(string name, string oldPassword, string newPassword)
        {
            List<User> users = (List<User>)Unit.users.GetAll();

            foreach (var item in users)
            {
                if (item.name == name)
                {
                    byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(oldPassword, Convert.FromHexString(item.salt), 1000, HashAlgorithmName.SHA1, 64);

                    if (hashToCompare.SequenceEqual(Convert.FromHexString(item.hash)))
                    {
                        byte[] salt = RandomNumberGenerator.GetBytes(64);

                        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                            Encoding.UTF8.GetBytes(newPassword),
                            salt, 1000, HashAlgorithmName.SHA1, 64);

                        item.salt = Convert.ToHexString(salt);
                        item.hash = Convert.ToHexString(hash);

                        Unit.users.Update(item);
                        Unit.Save();

                        return (true, "");
                    }
                    else
                    {
                        return (false, "Неверный пароль");
                    }
                }
            }
            
            return (false, "");
        }
    }
}