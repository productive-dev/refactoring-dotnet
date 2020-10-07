using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Refactoring.Web.Models;

namespace Refactoring.Web.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            _logger.LogDebug("Index loaded");
            var districts = new List<string> {
                "Cambridge", "Downtown", "County", "Middleton"
            };
            var viewModel = new OrderFormModel {
                Districts = districts.Select(d => new SelectListItem {
                    Value = d.ToLower(), 
                    Text = d
                })
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
