using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.OrderProcessors {
    public class CountyOrderProcessor : OrderProcessor {
        private readonly IAdvertPrinter _printer;

        public CountyOrderProcessor(IAdvertPrinter printer) {
            _printer = printer;
        }

        public override Task<Order> PrintAdvertAndUpdateOrder(Order order) {
            var advert = new Advert {
                CreatedOn = DateTime.Now, 
                Heading = "County Diner", 
                Content = "Kids eat free every Thursday night"
            };
            order.Advert = advert;
            _printer.PrintCustom(advert);
            order.Status = "Complete";
            return Task.FromResult(order);
        }
    }
}