using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_MVC.Models
{
    public class DocterRegister
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Must Enter the name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Add Experience")]
        public string Experience { get; set; }
        [Required(ErrorMessage ="Please Add Availability Status")]
        public string Availability { get; set; }
        [Required(ErrorMessage ="Please Add Specialization")]
        public string Specialization { get; set; }
        public string Message { get; set; }

    }
}
