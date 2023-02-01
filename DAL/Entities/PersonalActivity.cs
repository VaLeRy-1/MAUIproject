namespace DAL.Entities
{
    public class PersonalActivity
    {
        public int id { get; set; }
        public int steps { get; set; }
        public int calories { get; set; }
        public int water { get; set; }
        public DateTime date { get; set; }
        public int listId { get; set; }

    }
}