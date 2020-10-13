using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services {

    public class OrderService : IOrderService {
        private readonly IDistrictOrderFactory _districtOrderFactory;

        public OrderService(
            IDistrictOrderFactory districtOrderFactory) {
            _districtOrderFactory = districtOrderFactory;
        }

        public async Task<Order> ProcessOrder(Order order) {
            order.Id = Guid.NewGuid().ToString();
            order.CreatedOn = DateTime.Now;
            order.UpdatedOn = DateTime.Now;
            var orderProcessor = _districtOrderFactory.For(order.District);
            return await orderProcessor.PrintAdvertAndUpdateOrder(order);
        }
    }
}