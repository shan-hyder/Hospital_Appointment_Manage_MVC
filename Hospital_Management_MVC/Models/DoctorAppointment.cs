namespace Hospital_Management_MVC.Models
{
    public class DoctorAppointment
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public string Timeslot { get; set; }
        public string Status { get; set; }
    }
    public class Appointments
    {
        public List<DoctorAppointment> Appointment { get; set; } = new List<DoctorAppointment>();
    }
}
