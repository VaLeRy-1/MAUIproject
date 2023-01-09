namespace DAL.Entities
{
    public class DifficultyLevel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int[] training { get; set; }
    }
}
