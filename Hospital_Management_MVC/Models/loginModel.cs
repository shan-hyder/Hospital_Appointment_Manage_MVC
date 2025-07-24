using System.ComponentModel.DataAnnotations;


namespace Hospital_Management_MVC.Models
{
    public class loginModel
    {
        [Required(ErrorMessage ="Username cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
