using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.OrderProcessors {
        public class CambridgeOrderProcessor : OrderProcessor {
            private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
            private readonly IAdvertPrinter _printer;
            private readonly IDateTimeResolver _dateResolver;

            public CambridgeOrderProcessor(
                IChamberOfCommerceApi chamberOfCommerceApi,
                IAdvertPrinter printer,
                IDateTimeResolver dateResolver) {
                _chamberOfCommerceApi = chamberOfCommerceApi;
                _printer = printer;
                _dateResolver = dateResolver;
            }
            
            public override async Task<Order> PrintAdvertAndUpdateOrder(Order order) {
                var advert = new Advert {
                    CreatedOn = DateTime.Now,
                    Heading = "Cambridge Bakery",
                    Content = "Custom Birthday and Wedding Cakes"
                };
                if (_dateResolver.IsItTuesday()) {
                    var result = await _chamberOfCommerceApi
                        .GetImageAndThumbnailDataFor(District.Cambridge);
                    advert.ImageUrl = result.ThumbnailUrl;
                }
                order.Advert = advert;
                _printer.PrintCustom(advert);
                order.Status = "Complete";
                return order;
            }
        }
}