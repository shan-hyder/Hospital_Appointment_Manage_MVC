using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_MVC.Models
{
    public class userRegister
    {
        public int Userid { get; set; }
        [Required(ErrorMessage ="Email is not in the correct format")]
        [EmailAddress]
    
        public string Email { get; set; }
        [Required(ErrorMessage ="Username cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password cannot be empty")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public string Message { get; set; }
    }
}
