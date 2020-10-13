using Refactoring.Web.DomainModels;

namespace Refactoring.Web.Services.Interfaces {
        public interface IAdvertPrinter {
            void PrintDefault(Advert advert);
            void PrintCustom(Advert advert);
        }
}