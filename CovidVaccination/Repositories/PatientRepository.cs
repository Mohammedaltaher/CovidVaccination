using CovidVaccination.Interfaces;
using CovidVaccination.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace CovidVaccination.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Patient> GetAllPatientsWithVaccinationHistory()
        {
            return _context.Patients.Include("Vaccinations");
        }
        public Patient GetByIdInclude(int Id)
        {
            return _context.Patients.Include("Vaccinations").FirstOrDefault(x=>x.Id==Id);
        }
    }
}
