using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_MVC.Controllers
{
    public class DoctorHomeController : Controller
    {
        public IActionResult Doctorload()
        {
            return View();
        }
    }
}
