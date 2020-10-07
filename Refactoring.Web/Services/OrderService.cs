using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;

namespace Refactoring.Web.Services {
    public class OrderService{
        private readonly Order _order;

        public OrderService(Order order) {
            _order = order;
            _order.Id = Guid.NewGuid().ToString();
            _order.CreatedOn = DateTime.Now;
            _order.UpdatedOn = DateTime.Now;
        }

        public async Task ProcessOrder() {
            if (_order.District.ToLower() == "cambridge") {
                var advert = new Advert();
                advert.CreatedOn = DateTime.Now;
                advert.Heading = "Cambridge Bakery";
                advert.Content = "Custom Birthday and Wedding Cakes";
                if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) {
                    var result = await ChamberOfCommerceApi.GetFor("Middleton");
                    advert.ImageUrl = result.ThumbnailUrl;
                }
                _order.Advert = advert;
                PrintAdvert(advert, false);
                _order.Status = "Complete";
            } else if (_order.District.ToLower() == "middleton") {
                var advert = new Advert();
                advert.CreatedOn = DateTime.Now;
                var svc = new DealService();
                var deal = svc.GenerateDeal(DateTime.Now);
                var biz = svc.GetRandomLocalBusiness();
                advert.Heading = "Middleton " + biz;
                advert.Content = "Get " + deal * 100 + "Percent off your next purchase!";
                var result = await ChamberOfCommerceApi.GetFor("Middleton");
                advert.ImageUrl = result.ThumbnailUrl;
                _order.Advert = advert;
                PrintAdvert(advert, false);
                _order.Status = "Complete";
            } else if (_order.District.ToLower() == "county") {
                var advert = new Advert();
                advert.CreatedOn = DateTime.Now;
                advert.Heading = "County Diner";
                advert.Content = "Kids eat free every Thursday night";
                _order.Advert = advert;
                PrintAdvert(advert, false);
                _order.Status = "Complete";
            } else if (_order.District.ToLower() == "downtown") {
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday) {
                    PrintAdvert(null, true);
                }
                var advert = new Advert();
                advert.Heading = "Downtown Coffee Roasters";
                advert.CreatedOn = DateTime.Now;
                advert.Content = "Get a free coffee drink when you buy 1lb of coffee beans";
                _order.Advert = advert;
                PrintAdvert(advert, false);
                _order.Status = "Complete";
            }
        }

        private void PrintAdvert(Advert advert, bool IsDefaultAdvert) {
            if (IsDefaultAdvert) {
                Console.WriteLine("Printing Default Advert");
            }
            else {
                Console.WriteLine("Printing Custom Advert: " + advert.Heading);
            }
            System.Threading.Thread.Sleep(3000);
        }

        public Order GetOrder() {
            return _order;
        }
    }
}