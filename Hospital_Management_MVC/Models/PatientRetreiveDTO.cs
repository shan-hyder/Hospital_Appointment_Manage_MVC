namespace Hospital_Management_MVC.Models
{
    public class PatientRetreiveDTO
    {
        public int id { get; set; }
        public int Userid { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string  Gender {get;set;}

        public string Medicalhistory { get; set; }
    }
}
