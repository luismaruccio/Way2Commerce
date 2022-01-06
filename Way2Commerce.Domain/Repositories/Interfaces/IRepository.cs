namespace Way2Commerce.Domain.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetById(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<int> Insert(T entity);
        public Task<int> Update(T entity);
        public Task<bool> DeleteById(int id);
        public Task<T> GetByIdNoTracking(int id);
    }
}
