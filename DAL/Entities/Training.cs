using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Training
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int[] exercises { get; set; }

    }
}