using AutoMapper;
using Netlog.Data.Entities;
using Netlog.Data.IRepositories;
using Netlog.Data.UnitOfWorks;
using Netlog.External.LCWaikikiClient;
using Netlog.Service.IServices;

namespace Netlog.Service.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILcWaikikiClient _lcWaikikiClient;

        public OrderService(IUnitOfWork unitOfWork, IGenericRepository<Order> repository, IOrderRepository orderRepository, ILcWaikikiClient lcWaikikiClient) : base(unitOfWork, repository)
        {
           
            _orderRepository = orderRepository;
            _lcWaikikiClient = lcWaikikiClient;
        }

        public async Task<bool> OrderImportService(string deliveryPerson, string plate)
        {
            var lcWaikikiResponse = await _lcWaikikiClient.GetLcWaikikiOrders();

            var orders = new List<Order>();
            foreach (var orderItem in lcWaikikiResponse)
            {
                var productList = new List<Product>();
                if (orderItem.Products != null)
                {
                    foreach (var lcWaikikiOrderProduct in orderItem.Products)
                    {
                        productList.Add(new Product
                        {
                            Id = lcWaikikiOrderProduct.Id,
                            Quantity = lcWaikikiOrderProduct.Quantity,
                            ProductName = lcWaikikiOrderProduct.ProductName
                        });
                    }
                }
               

                orders.Add(new Order
                {
                    Id = orderItem.Id,
                    DispatchPoint = orderItem.DispatchPoint,
                    Receiver = orderItem.Receiver,
                    ContactPhone = orderItem.ContactPhone,
                    //Products = productList,
                    OrderDate = orderItem.OrderDate,


                });

            }

            var delivery = new Delivery
            {
                DeliveryPerson = deliveryPerson,
                DeliveryDate = DateTime.Now,
                Plate = plate,
                Status = 1,
                //Orders = orders

            };
            return await _orderRepository.OrderImport(delivery: delivery);
        }


    }
}
