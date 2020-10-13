using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;
using Xunit;

namespace Refactoring.Tests.Tests.Services.OrderProcessors {
    public class TestMiddletonOrderProcessor {
        [Theory]
        [InlineData(0.05, "Get 5.00% off your next purchase!")]
        [InlineData(0.08, "Get 8.00% off your next purchase!")]
        [InlineData(0.18, "Get 18.00% off your next purchase!")]
        public async Task Given_ItIsMorning_PrintAdvertAndUpdateOrder_Returns_Order_With_AdvertContent_AmDealRate(
            decimal inputDeal, string expectedContent) {
            // Arrange
            var testOrder = new Order {
                Id = "foo"
            };

            var fakeDealService = new Mock<IDealService>();
            fakeDealService.Setup(m => m.GenerateDeal(It.IsAny<DateTime>()))
                .Returns(inputDeal);
            
            var fakeChamberOfCommerce = new Mock<IChamberOfCommerceApi>();
            var fakePrinter = new Mock<IAdvertPrinter>();
            var fakeRandom = new Mock<IRandomHelper>();
            
            var sut = new MiddletonOrderProcessor(
                fakeDealService.Object,
                fakeChamberOfCommerce.Object,
                fakePrinter.Object,
                fakeRandom.Object
                );

            // Act 
            var order = await sut.PrintAdvertAndUpdateOrder(testOrder);

            // Assert 
            order.Advert.Content.Should().Be(expectedContent);
        }
    }
}