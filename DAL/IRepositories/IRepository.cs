namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Insert(T row);
        void Update(T row);
        void Delete(int Id);
    }
}