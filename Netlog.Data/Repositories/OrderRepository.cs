using Netlog.Data.Entities;
using Netlog.Data.IRepositories;


namespace Netlog.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> OrderImport(Delivery delivery)
        {

            {
              var response =  await _dbContext.Deliverys.AddAsync(delivery);
              if (response !=null)
              {
                  return true;
              }

              return false;


            }
        }
    }
}
