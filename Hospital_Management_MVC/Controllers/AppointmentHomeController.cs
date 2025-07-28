using Hospital_Management_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [HttpGet]
        public IActionResult AppointmentDoctor()
        {
            int doctorId = (int)HttpContext.Session.GetInt32("Userid");
            DoctorRetrieveDTO doctor= dbconect.GetDoctor(doctorId);
            ViewBag.name = doctor.Name;
            var model = new DoctorAppointmentView
            {
                Patients=dbconect.GetAllPatients(),
                BookedSlots=new List<string>(),
                selectedDocterid= doctorId,

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AppointmentDoctor(DoctorAppointmentView model,string action)
        {
            if(action=="View Slots")
            {

                var bookedSlots = dbconect.GetBookedSlots(model.selectedDocterid,model.Date);
                model.BookedSlots = bookedSlots;
                model.Patients = dbconect.GetAllPatients();
                DoctorRetrieveDTO doctor= dbconect.GetDoctor(model.selectedDocterid);
                ViewBag.name = doctor.Name;
                return View(model);

            }
            if(action=="Book Appointment")
            {
                var addapp = new addAppointment
                {
                    PatientId = model.selectedPatintid,
                    DoctorId = model.selectedDocterid,
                    Date = model.Date,
                    TimeSlot = model.Timeslot,
                    Status = "Pending"
                };
                dbconect.AddAppointment(addapp);
                TempData["message"] = "Appointment Added Successfully";
                ModelState.Clear();
                model = new DoctorAppointmentView();
                model.Patients = dbconect.GetAllPatients();
                model.BookedSlots = new List<string>();
                return View(model);
            }
            TempData["message"] = "Invalid action";
            return RedirectToAction("AppointmentDoctor");
        } 
            
    }
}
