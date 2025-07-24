using System.Diagnostics;
using Hospital_Management_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }

}
