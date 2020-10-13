using System;
using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;

namespace Refactoring.Web.Services {
    public class DistrictOrderFactory : IDistrictOrderFactory {
        private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
        private readonly IAdvertPrinter _printer;
        private readonly IDealService _dealService;
        private readonly IDateTimeResolver _dateTimeResolver;
        private readonly IRandomHelper _randomHelper;

        public DistrictOrderFactory(
            IChamberOfCommerceApi chamberOfCommerceApi, 
            IAdvertPrinter printer, 
            IDealService dealService,
            IDateTimeResolver dateTimeResolver,
            IRandomHelper randomHelper) {
            _chamberOfCommerceApi = chamberOfCommerceApi;
            _printer = printer;
            _dealService = dealService;
            _dateTimeResolver = dateTimeResolver;
            _randomHelper = randomHelper;
        }
        
        public OrderProcessor For(string district) {
            if (district.ToLower() == District.Cambridge) {
                return new CambridgeOrderProcessor(
                    _chamberOfCommerceApi, 
                    _printer, 
                    _dateTimeResolver);
            }

            if (district.ToLower() == District.Middleton) {
                return new MiddletonOrderProcessor(
                    _dealService, 
                    _chamberOfCommerceApi, 
                    _printer,
                    _randomHelper);
            }

            if (district.ToLower() == District.County) {
                return new CountyOrderProcessor(_printer);
            }

            if (district.ToLower() == District.Downtown) {
                return new DowntownOrderProcessor(_printer, _dateTimeResolver);
            }

            throw new NotImplementedException($"No Processor for {district}");
        }
    }
}