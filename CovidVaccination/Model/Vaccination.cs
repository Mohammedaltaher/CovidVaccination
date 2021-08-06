using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CovidVaccination.Model
{
    public class Vaccination
    {
        public Vaccination()
        {
            this.Date = DateTime.Now;
        }
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public  Patient Patient { get; set; }
    }
}
