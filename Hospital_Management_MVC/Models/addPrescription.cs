using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_MVC.Models
{
    public class addPrescription
    {
        public int Id { get; set; }
        public int Appointmentid { get; set; }
        [Required(ErrorMessage ="Please add Medicine name ")]
        public string Medicines { get; set; }
        [Required(ErrorMessage ="Please add dosage")]
        public string Dosage { get; set; }
        public string Notes { get; set; }
    }
}
