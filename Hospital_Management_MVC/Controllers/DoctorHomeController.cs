using Hospital_Management_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_MVC.Controllers
{
    public class DoctorHomeController : Controller
    {
        DbConnection con = new DbConnection();
        public IActionResult Doctorload()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("Doctorid"));

            if (id == 0)
            {
                TempData["message"] = "Cannot find doctor";
                return RedirectToAction("Login_load", "Login");
            }
            ViewBag.name = HttpContext.Session.GetString("Name");

            var model = con.GetAppointmentsbydoctor(id);
            if (model == null || model.Count == 0)
            {
                TempData["message"] = "No Appointments Found";
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult DeleteAppointment(int id)
        {
            if (id == 0)
            {
                TempData["message"] = "Invalid Appointment ID";
                return RedirectToAction("Doctorload");
            }
            con.deleteappointment(id);
            TempData["message"] = "Appointment Deleted Successfully";
            return RedirectToAction("Doctorload");
        }
        [HttpPost]
        public IActionResult UpdateAppointment(int id)
        {
            if (id != 0)
            {
                string s = con.UpdateAppointmentStatus(id);
                TempData["message"] = s;
                return RedirectToAction("Doctorload");
            }
            TempData["message"] = "Update failed";
            return RedirectToAction("Doctorload");
        }
    }
}
