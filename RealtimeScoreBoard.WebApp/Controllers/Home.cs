using Microsoft.AspNetCore.Mvc;

namespace RealtimeScoreBoard.WebApp.Controllers
{
    public class Home : Controller
    {

        public IActionResult Index()
        {

            return View();
        }


    }
}
