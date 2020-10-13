using System.Threading.Tasks;

namespace Refactoring.Web.Services.Interfaces {
    public interface IChamberOfCommerceApi {
        Task<DataResult> GetImageAndThumbnailDataFor(string district);
    }
}