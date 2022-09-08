using Netlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netlog.Service.IServices
{
    public interface IOrderService : IService<Order>
    {
        public Task<bool> OrderImportService(string deliveryPerson, string plate);
    }
}
