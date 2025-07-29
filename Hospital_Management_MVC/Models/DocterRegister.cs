using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_MVC.Models
{
    public class DocterRegister
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        [Required(ErrorMessage = "Email is not in the correct format")]
        [EmailAddress]

        public string Email { get; set; }
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [BindNever]
        public string? User_Role { get; set; }
       
        [Required(ErrorMessage ="Must Enter the name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Add Experience")]
        public string Experience { get; set; }
        [Required(ErrorMessage ="Please Add Availability Status")]
        public string Availability { get; set; }
        [Required(ErrorMessage ="Please Add Specialization")]
        public string Specialization { get; set; }
        [BindNever]
        public string? Message { get; set; }
    }
}
