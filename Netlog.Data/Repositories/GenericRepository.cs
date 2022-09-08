using Netlog.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netlog.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
