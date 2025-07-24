using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_MVC.Models
{
    public class addAppointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Please choose the date")]
        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "Select Time Slot")]
        public string TimeSlot { get; set; }
        public string Status { get; set; }

    }
}
