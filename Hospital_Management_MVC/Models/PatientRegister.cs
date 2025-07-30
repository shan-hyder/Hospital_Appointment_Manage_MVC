using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_MVC.Models
{
    public class PatientRegister
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        [Required(ErrorMessage ="Please enter the Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the Age")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Please select date of birth")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please choose the gender")]
        public string Gender { get; set; }
        public string Medicalhistory { get; set; }
        [Required(ErrorMessage = "Please enter the Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter the Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string User_Role { get; set; } = "PATIENT";
    }
}
