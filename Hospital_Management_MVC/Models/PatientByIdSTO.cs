namespace Hospital_Management_MVC.Models
{
    public class PatientByIdSTO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Medicalhistory { get; set; }
    }
}
