using Microsoft.AspNetCore.Mvc;

namespace SampleApp1.Web.MVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return Ok(new { Message = "Hello, world!" });
        }
    }
}
