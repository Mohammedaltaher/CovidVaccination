using CovidVaccination.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidVaccination.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        public IEnumerable<Patient> GetAllPatientsWithVaccinationHistory();
        public Patient GetByIdInclude(int Id);
    }

}
