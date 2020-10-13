using System.Collections.Generic;

namespace Refactoring.Web.Services.Helpers {
    public static class District {
        public static string Cambridge => "cambridge";
        public static string Downtown => "downtown";
        public static string County => "county";
        public static string Middleton => "middleton";

        private static int DowntownId => 11;
        private static int CountyId => 23;
        private static int MiddletonId => 18;
        private static int CambridgeId => 42;
        
        public static IEnumerable<string> StandardDistricts =>  new List<string> {
            Cambridge, Downtown, County, Middleton
        };

        public static int GetDistrictNumberByName(string name) {
            var districtLookup = new Dictionary<string, int>() {
                {Downtown,  DowntownId},
                {County,    CountyId},
                {Middleton, MiddletonId},
                {Cambridge, CambridgeId}
            };
            return districtLookup[name];
        }
    }
    
}