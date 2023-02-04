namespace DAL.Entities
{
    public class Training
    {
        public int id { get; set; }
        public string name { get; set; }
        public int time { get; set; }
        public int quantity { get; set; }
        public int difficultyLevelId { get; set; }
        public int exerciseListId { get; set; }
        public int trainingListId { get; set; }

    }
}