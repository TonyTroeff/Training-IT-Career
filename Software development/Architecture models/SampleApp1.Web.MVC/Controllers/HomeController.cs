using Microsoft.AspNetCore.Mvc;
using SampleApp1.Web.ViewModels.Common;
using System.Diagnostics;

namespace SampleApp1.Web.MVC.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
