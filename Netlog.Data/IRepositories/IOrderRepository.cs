using Netlog.Data.Entities;

namespace Netlog.Data.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    { 
        public Task<bool> OrderImport(Delivery delivery);
    }
}