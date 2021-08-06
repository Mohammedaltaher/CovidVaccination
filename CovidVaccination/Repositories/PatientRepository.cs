using CovidVaccination.Interfaces;
using CovidVaccination.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidVaccination.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
