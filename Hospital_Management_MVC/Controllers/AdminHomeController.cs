using Microsoft.AspNetCore.Mvc;
using Hospital_Management_MVC.Models;

namespace Hospital_Management_MVC.Controllers
{
    public class AdminHomeController : Controller
    {
        DbConnection con = new DbConnection();
        AdminRetriveDTO dtoadmin = new AdminRetriveDTO();
        public IActionResult Adminload()
        {

            int id = Convert.ToInt32(HttpContext.Session.GetInt32("Userid"));
            if (id == 0)
            {
                TempData["message"] = "Cannot find admin";
                return RedirectToAction("Login_load", "Login");
            }
            var dtoadmin = con.GetAdmin(id);
            if (dtoadmin == null)
            {
                TempData["message"] = "Cannot find admin";
                return RedirectToAction("Login_load", "Login");
            }
            ViewBag.name = dtoadmin.Name;

            return View(dtoadmin);

        }
        [HttpGet]
        public IActionResult ManageDoctor()
        {
            if (HttpContext.Session.GetInt32("Userid") != null)
            {
                var docters = con.GetAllDoctors();
                if (docters == null || docters.Count == 0)
                {
                    TempData["message"] = "No Docters Added Yet";
                    return RedirectToAction("Adminload");
                }
                else
                {
                    return View(docters);
                }
            }
            else
            {
                TempData["message"] = "Please Login First";
                return RedirectToAction("Login_load", "Login");
            }
        }
        [HttpGet]
        public IActionResult UpdateDoctor(int id)
        {
            var doctor = con.GetDoctorById(id);
            if(doctor==null)
            {
                TempData["message"] = "Doctor not found";
                return RedirectToAction("ManageDoctor");
            }
            return View(doctor);
        }
        [HttpPost]
        public IActionResult UpdateDoctor(DoctorbyidDTO model)
        {
            var doctor = new DoctorbyidDTO
            {
                Id=model.Id,
                Userid = model.Userid,
                Name = model.Name,
                Experience = model.Experience,
                Availability = model.Availability,
                Specialization = model.Specialization,

            };
             TempData["message"]=con.UpdateDoctor(doctor);

            return RedirectToAction("ManageDoctor");
          
        }
        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDoctor(DocterRegister docterRegister)
        {
            if(ModelState.IsValid)
            {
                var docter = new userRegister
                {
                    Email = docterRegister.Email,
                    Username = docterRegister.Username,
                    Password = docterRegister.Password,
                    User_Role = "DOCTOR"

                };
                string msg = con.createUser(docter);
                if (msg == "User Inserted Successfully")
                {
                    userRetrieveDTO user = con.Getuserinfo(docter.Username, docter.Password);
                    int userid = user.Userid;
                    var doctor = new DocterRegister
                    {
                        Userid = userid,
                        Name = docterRegister.Name,
                        Experience = docterRegister.Experience,
                        Availability = docterRegister.Availability,
                        Specialization = docterRegister.Specialization

                    };
                    string msg1 = con.RegisterDocter(doctor);
                    ViewBag.message = msg1;
                    ModelState.Clear();
                    return RedirectToAction("ManageDoctor");
                }
                else
                {
                    TempData["message"] = msg;
                    return RedirectToAction("ManageDoctor");


                }
            }
            else
            {
                TempData["message"] = "Please fill all the fields correctly";
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state.Errors.Count > 0)
                    {
                        // Log or inspect state.Errors[0].ErrorMessage
                    }
                }
                return View(docterRegister);
            }
        }
        [HttpPost]
        public IActionResult DeleteDoctor(int id)
        {
            if(id==0)
            {
                TempData["message"] = "Doctor doesnt exist";
                return RedirectToAction("ManageDoctor");
            }else
            {
                TempData["message"] = con.DeleteDoctor(id);
                return RedirectToAction("ManageDoctor");
            }
        }
    }
}


