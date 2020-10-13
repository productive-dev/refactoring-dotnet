using System.Threading.Tasks;
using Refactoring.Web.DomainModels;

namespace Refactoring.Web.Services.OrderProcessors {
    public abstract class OrderProcessor {
        public abstract Task<Order> PrintAdvertAndUpdateOrder(Order order);
    }
}