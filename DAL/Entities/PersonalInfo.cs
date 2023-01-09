using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PersonalInfo
    {
        public int id { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public User User { get; set; }
    }
}