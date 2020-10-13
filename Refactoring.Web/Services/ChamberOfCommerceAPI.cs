using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services {
    public class ChamberOfCommerceApi : IChamberOfCommerceApi {
        private readonly IConfiguration _config;

        public ChamberOfCommerceApi(IConfiguration config) {
            _config = config;
        }
        
        /// <summary>
        /// For the provided `district` returns the `DataResult` object containing
        /// the id, thumbnail url, and title for the district's image
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        public async Task<DataResult> GetImageAndThumbnailDataFor(string district) {
            using var client = new HttpClient();
            var absoluteUrl = BuildUrlForDistrict(district);
            var request = new HttpRequestMessage(HttpMethod.Get, absoluteUrl);
            var response = client.SendAsync(request);
            var data = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DataResult>(data);
            return result;
        }

        private Uri BuildUrlForDistrict(string district) {
            var districtId = District.GetDistrictNumberByName(district);
            var basePhotoUrl = new Uri(_config.GetValue<string>("BasePhotoUrl"));
            return new Uri(basePhotoUrl, districtId.ToString());
        }
    }

    public struct DataResult {
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
    }
}