namespace Hospital_Management_MVC.Models
{
    public class DoctorRetrieveDTO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string Availability { get; set; }
        public string Specialization { get; set; }
    }
    public class Docters
    {
        public List<DoctorRetrieveDTO> AllDocters { get; set; } = new List<DoctorRetrieveDTO>();
    }
}
