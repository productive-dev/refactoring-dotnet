using System.Threading.Tasks;
using Refactoring.Web.DomainModels;

namespace Refactoring.Web.Services.Interfaces {
    public interface IOrderService {
        Task<Order> ProcessOrder(Order order);
    }
}