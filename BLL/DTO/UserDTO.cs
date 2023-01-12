namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Password { get; set; }
    }
}