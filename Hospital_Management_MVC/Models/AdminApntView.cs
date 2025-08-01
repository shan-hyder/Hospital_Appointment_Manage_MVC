﻿using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_MVC.Models
{
    public class AdminApntView
    {
        public List<DoctorRetrieveDTO> Docters { get; set; }
        public List<PatientRetreiveDTO> Patients { get; set; }
        [Required(ErrorMessage ="Please choose a patient")]
        public int selectedPatintid { get; set; }
        [Required(ErrorMessage ="Please choose a doctor")]
        public int selectedDocterid { get; set; }
        [Required(ErrorMessage ="please choose a date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Please select a time slot")]
        public string Timeslot { get; set; }
        public string Status { get; set; }
        public List<string> BookedSlots { get; set; } = new List<string>();

        public List<AppointmentDTO> AllAppointments { get; set; } = new List<AppointmentDTO>();

    }
}
