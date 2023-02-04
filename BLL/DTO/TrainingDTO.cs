namespace BLL.DTO
{
    public class TrainingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int Quantity { get; set; }
        public string Difficulty { get; set; }
        public int ExerciseListId { get; set; }
        public int TrainingListId { get; set; }
    }
}
