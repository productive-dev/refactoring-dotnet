using System;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.Printers {
    public class AdvertPrinter : IAdvertPrinter {
        public void PrintCustom(Advert advert) {
            Console.WriteLine("Printing Custom Advert: " + advert.Heading);
            System.Threading.Thread.Sleep(3000);
        }

        public void PrintDefault(Advert advert) {
            Console.WriteLine("Printing Default Advert");
            System.Threading.Thread.Sleep(3000);
        }
    }
}