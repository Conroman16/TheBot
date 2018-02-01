using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheBot.Models;

namespace TheBot.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Landing");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
