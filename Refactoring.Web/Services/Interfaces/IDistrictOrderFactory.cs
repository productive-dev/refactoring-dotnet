using Refactoring.Web.Services.OrderProcessors;

namespace Refactoring.Web.Services.Interfaces {
    public interface IDistrictOrderFactory {
        OrderProcessor For(string district);
    }
}