using Microsoft.AspNetCore.Mvc;
using Hospital_Management_MVC.Models;

namespace Hospital_Management_MVC.Controllers
{
    public class AppointmentHomeController : Controller
    {

        DbConnection dbconect = new DbConnection();
        public IActionResult Appointment_Load()
        {
            if (HttpContext.Session.GetInt32("Userid") == null)
            {
                TempData["message"] = "please login first";
                return RedirectToAction("Login_load", "Login");
            }
            if(HttpContext.Session.GetString("Role")=="DOCTOR")
            {
                return RedirectToAction("AppointmentDoctor");
            }
            if(HttpContext.Session.GetString("Role")=="ADMIN")
            {
                return RedirectToAction("AppointmentAdmin");
            }
            if(HttpContext.Session.GetString("Role")=="PATIENT")
            {
                return RedirectToAction("AppointmentPatient");
            }

            return View();
        }
        [HttpGet]
        public IActionResult AppointmentAdmin()
        {
            var model = new AdminApntView
            {
                Docters = dbconect.GetAllDoctors(),
                Patients = dbconect.GetAllPatients(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AppointmentAdmin(AdminApntView apntview)
        {
            if(ModelState.IsValid)
            {
                var model = new addAppointment
                {
                   PatientId=apntview.selectedPatintid,
                   DoctorId=apntview.selectedDocterid,
                   Date=apntview.Date,
                   TimeSlot=apntview.Timeslot,
                   Status="Pending"
                };
                dbconect.AddAppointment(model);
                TempData["message"] = "Appointment Added Succcessfully";
                ModelState.Clear();
                apntview = new AdminApntView();
            }
            else
            {
                TempData["message"] = "Please fill all the fields correctly";
            }
            apntview.Docters = dbconect.GetAllDoctors();
            apntview.Patients = dbconect.GetAllPatients();
            return View(apntview);
        }
    }
}
