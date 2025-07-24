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
        public DateOnly DOB { get; set; }
        [Required(ErrorMessage = "Please choose the gender")]
        public string Gender { get; set; }
        public string Medicalhistory { get; set; }
    }
}
