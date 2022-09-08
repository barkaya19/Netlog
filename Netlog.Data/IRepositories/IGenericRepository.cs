namespace Netlog.Data.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
    }
}
