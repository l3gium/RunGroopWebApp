using Microsoft.AspNetCore.Mvc;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        public ClubController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
