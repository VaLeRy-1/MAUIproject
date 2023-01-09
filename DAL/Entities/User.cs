namespace DAL.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string hash { get; set; }
        public string salt { get; set; }

        public int infoId { get; set; }
        public PersonalInfo personalInfo { get; set; }

        public int activityId { get; set; }
        public PersonalActivity personalActivity { get; set; }

        public int bodyId { get; set; }
        public BodyParameters bodyParameters { get; set; }

    }
}