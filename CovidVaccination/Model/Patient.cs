using System;
using System.Collections.Generic;
using System.Text;
using CovidVaccination.Enum;

namespace CovidVaccination.Model
{
    public class Patient
    {
        public Patient()
        {
            this.DateOfRegistration = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public Gender Gender { get; set; }
        public bool VaccinationStatus { get; set; }

        public virtual ICollection<Vaccination> Vaccinations { get; set; }
    }
}
