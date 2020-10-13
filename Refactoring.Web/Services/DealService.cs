using System;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services {
    public class DealService : IDealService {
        public static decimal PmRate => 0.1M;
        public static decimal AmRate => 0.05M;

        public decimal GenerateDeal(DateTime dateTime) 
            => IsAfternoon(dateTime) ? PmRate : AmRate;

        private static bool IsAfternoon(DateTime dateTime) 
            => dateTime.Hour > 12 
               && dateTime.Hour < 24;
    }
}