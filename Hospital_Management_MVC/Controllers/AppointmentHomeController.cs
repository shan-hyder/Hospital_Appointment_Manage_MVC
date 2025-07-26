using Microsoft.AspNetCore.Mvc;
using Hospital_Management_MVC.Models;
using System.Linq;

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
                BookedSlots = new List<string>()
            };
            if (TempData["message"]!=null)
            {
                ViewBag.message = TempData["message"];
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult AppointmentAdmin(AdminApntView apntview)
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
            
        
            apntview.Docters = dbconect.GetAllDoctors();
            apntview.Patients = dbconect.GetAllPatients();
            apntview.BookedSlots = new List<string>();
            return View(apntview);
        }
        [HttpPost]
        public IActionResult BookedSlots(AdminApntView apntmnt)
        {
            if(apntmnt.selectedDocterid!=0 && apntmnt.Date!=default)
            {
                DateTime date = apntmnt.Date;
                int doctorId = apntmnt.selectedDocterid;
                var bookedSlots = dbconect.GetBookedSlots(doctorId,date);

                ViewBag.doctorid = doctorId;
                ViewBag.date = date;
                apntmnt.Docters = dbconect.GetAllDoctors();
                apntmnt.Patients = dbconect.GetAllPatients();
                apntmnt.BookedSlots = bookedSlots;
                ViewBag.patientid= apntmnt.selectedPatintid;

                return View("AppointmentAdmin",apntmnt);
            }
            TempData["message"] = "please choose doctor and patient to see available slots";
            return RedirectToAction("AppointmentAdmin");

        }
    }
}
