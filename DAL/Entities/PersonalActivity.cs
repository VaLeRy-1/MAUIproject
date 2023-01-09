using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PersonalActivity
    {
        public int id { get; set; }
        public int steps { get; set; }
        public int calories { get; set; }
        public int water { get; set; }

        public User User { get; set; }

    }
}