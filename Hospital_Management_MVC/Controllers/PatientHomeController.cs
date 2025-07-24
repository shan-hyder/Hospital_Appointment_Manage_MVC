using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_MVC.Controllers
{
    public class PatientHomeController : Controller
    {
        public IActionResult Patientload()
        {
            return View();
        }
    }
}
