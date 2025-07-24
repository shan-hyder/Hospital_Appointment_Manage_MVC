using Hospital_Management_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Hospital_Management_MVC.Controllers
{
    public class LoginController : Controller
    {
        DbConnection conn = new DbConnection();
        public IActionResult Login_load()
        {
            ViewBag.message = TempData["message"];
            return View();
        }
        [HttpPost]
        public IActionResult Login_Click(loginModel modelobject)
        {
            if(ModelState.IsValid)
            {
                int count=conn.logincheck(modelobject.Username, modelobject.Password);
                if (count == 1)
                {
                    userRetrieveDTO userdetail = null;



                    userdetail = conn.Getuserinfo(modelobject.Username, modelobject.Password);

                    string role = userdetail.Role;

                    HttpContext.Session.SetInt32("Userid", userdetail.Userid);
                    HttpContext.Session.SetString("Role", userdetail.Role);

                    if (role == "ADMIN")
                    {
                        return RedirectToAction("Adminload", "AdminHome");
                    }
                    else if (role == "DOCTOR")
                    {
                        return RedirectToAction("Doctorload", "DoctorHome");
                    }
                    else if (role == "PATIENT")
                    {
                        return RedirectToAction("Patientload", "PatientHome");
                    }
                    else
                    {
                        TempData["message"] = "Contact Admin";
                        return RedirectToAction("Login_load");

                    }
                }
                else
                {
                    TempData["message"] = "User does not exist";
                    return RedirectToAction("Login_load");
                }
            }
            else
            {
                TempData["message"] = "Invalid login credentials";
                return RedirectToAction("Login_load");
            }

        }
    }
}
