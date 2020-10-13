using System.Collections.Generic;

namespace Refactoring.Web.Services.Helpers {
    public static class LocalBusiness {

        public static string Barbershop => "Barbershop";
        public static string Bakery => "Bakery";
        public static string ShoeStore => "Shoe Store";
        public static string PizzaPlace => "Pizza place";
        public static string Diner => "Diner";
        public static string AutoRepair => "Auto Repair";
        public static string Pharmacy => "Pharmacy";
        public static string Grocery => "Grocery";
        
        public static HashSet<string> AllBusinesses 
            => new HashSet<string> {
            Barbershop, 
            Bakery, 
            ShoeStore, 
            PizzaPlace, 
            Diner, 
            AutoRepair, 
            Pharmacy, 
            Grocery
        };
    }
}