using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Refactoring.Web.Models {
    public class OrderFormModel {
        public IEnumerable<SelectListItem> Districts { get; set; }
        public string SelectedDistrict { get; set; }
        public decimal OrderAmount { get; set; }
    }
}