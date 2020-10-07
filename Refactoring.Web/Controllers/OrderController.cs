using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;

namespace Refactoring.Web.Controllers {
    public class OrderController : Controller {
        public IActionResult Index() {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SubmitOrder(string selectedDistrict, decimal orderAmount) {
            var order = new Order();
            order.District = selectedDistrict;
            order.Total = orderAmount;
            var orderService = new OrderService(order);
            await orderService.ProcessOrder();
            var completedOrder = orderService.GetOrder();
            return View(completedOrder);
        }
    }
}