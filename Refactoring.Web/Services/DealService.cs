using System;
using System.Collections.Generic;

namespace Refactoring.Web.Services {
    public class DealService {
        public DealService() { }
        
        public decimal GenerateDeal(DateTime dateTime) {
            if (dateTime.Hour > 12 && dateTime.Hour < 24) {
                return 0.1M;
            } else {
                return 0.05M;
            }
        }

        public string GetRandomLocalBusiness() {
            var lbs = new List<string> {
                "Barbershop", "Bakery", "Shoe Store", "Pizza Place", "Diner", "Auto Repair", "Pharmacy", "Grocery", "Bakery"
            };
            var random = new Random();
            var idx = random.Next(lbs.Count);
            return lbs[idx];
        }
    }
}