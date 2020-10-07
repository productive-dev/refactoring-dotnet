using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Refactoring.Web.Services {
    public static class ChamberOfCommerceApi {
        public static async Task<DataResult> GetFor(string district) {
            var client = new HttpClient();
            var districtLookup = new Dictionary<string, int>() {
                {"downtown", 11},
                {"county", 23},
                {"middleton", 18},
                {"cambridge", 42}
            };
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://jsonplaceholder.typicode.com/photos/{districtLookup[district.ToLower()].ToString()}");
            var response = client.SendAsync(request);
            var data = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DataResult>(data);
            return result;
        }
    }

    public struct DataResult {
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
    }
}