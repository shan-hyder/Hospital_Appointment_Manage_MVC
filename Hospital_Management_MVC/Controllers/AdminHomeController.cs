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
                if(dtoadmin==null)
                {
                    TempData["message"] = "Cannot find admin";
                    return RedirectToAction("Login_load", "Login");
                }
                ViewBag.name = dtoadmin.Name;
              
                return View(dtoadmin);
 
        }
    }
}
