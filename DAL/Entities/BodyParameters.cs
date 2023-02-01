namespace DAL.Entities
{
    public class BodyParameters
    {
        public int id { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public int breast { get; set; }
        public int waist { get; set; }
        public int hips { get; set; }

        public User User { get; set; }

    }
}