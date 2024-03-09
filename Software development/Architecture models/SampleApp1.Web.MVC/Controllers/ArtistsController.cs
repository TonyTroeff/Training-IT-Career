using Microsoft.AspNetCore.Mvc;

namespace SampleApp1.Web.MVC.Controllers
{
    [Route("artists")]
    public class ArtistsController : Controller
    {
        [HttpGet("details")]
        public IActionResult Details(Guid id)
        {
            return this.Ok(id);
        }
    }
}
