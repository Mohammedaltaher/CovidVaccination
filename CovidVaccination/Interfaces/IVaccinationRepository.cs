using CovidVaccination.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidVaccination.Interfaces
{
    public interface IVaccinationRepository : IGenericRepository<Vaccination>
    {
        IEnumerable<Vaccination> GetPopularVaccinations(int count);
    }
}
