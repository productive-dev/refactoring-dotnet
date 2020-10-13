using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;
using Xunit;

namespace Refactoring.Tests.Tests.Services.OrderProcessors {
    public class TestCambridgeOrderProcessor {
        [Fact]
        public async void GivenDateIsTuesday_ImageUrl_Set_OnOrderAdvert() {
            // Arrange
            var testOrder = new Order {
                Id = "foo"
            };
            var fakeAdvertPrinter= new Mock<IAdvertPrinter>();
            
            var fakeDateTimeResolver = new Mock<IDateTimeResolver>();
            fakeDateTimeResolver.Setup(m => m.IsItTuesday()).Returns(true);
            
            var fakeChamberOfCommerceApi = new Mock<IChamberOfCommerceApi>();
            var fakeDataResult = new DataResult {
                ThumbnailUrl = "http://example.com/some_thumbnail.png",
                Title = "My Title..."
            };
            fakeChamberOfCommerceApi
                .Setup(m => m.GetImageAndThumbnailDataFor(It.IsAny<string>()))
                .Returns(Task.FromResult(fakeDataResult));
            
            var sut = new CambridgeOrderProcessor(
                fakeChamberOfCommerceApi.Object, 
                fakeAdvertPrinter.Object,
                fakeDateTimeResolver.Object);
            
            // Act
            var result = await sut.PrintAdvertAndUpdateOrder(testOrder);
            
            // Assert
            result.Advert.ImageUrl.Should().Be(fakeDataResult.ThumbnailUrl);
        }
        
        [Fact]
        public async void GivenDateIsNotTuesday_ImageUrl_NotSet_OnOrderAdvert() {
            // Arrange
            var testOrder = new Order {
                Id = "foo"
            };
            var fakeAdvertPrinter= new Mock<IAdvertPrinter>();
            
            var fakeDateTimeResolver = new Mock<IDateTimeResolver>();
            fakeDateTimeResolver.Setup(m => m.IsItTuesday()).Returns(false);
            
            var fakeChamberOfCommerceApi = new Mock<IChamberOfCommerceApi>();
            var fakeDataResult = new DataResult {
                ThumbnailUrl = "http://example.com/some_thumbnail.png",
                Title = "My Title..."
            };
            fakeChamberOfCommerceApi
                .Setup(m => m.GetImageAndThumbnailDataFor(It.IsAny<string>()))
                .Returns(Task.FromResult(fakeDataResult));
            
            var sut = new CambridgeOrderProcessor(
                fakeChamberOfCommerceApi.Object, 
                fakeAdvertPrinter.Object,
                fakeDateTimeResolver.Object);
            
            // Act
            var result = await sut.PrintAdvertAndUpdateOrder(testOrder);
            
            // Assert
            result.Advert.ImageUrl.Should().BeNull();
        }
    }
}