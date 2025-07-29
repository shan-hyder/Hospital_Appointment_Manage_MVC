namespace Hospital_Management_MVC.Models
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public string Timeslot { get; set; }
        public string Status { get; set; }
    }
}
