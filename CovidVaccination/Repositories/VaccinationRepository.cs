using CovidVaccination.Interfaces;
using CovidVaccination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidVaccination.Repositories
{
    public class VaccinationRepository : GenericRepository<Vaccination>, IVaccinationRepository
    {
        public VaccinationRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Vaccination> GetPopularVaccinations(int count)
        {
            return _context.Vaccinations.OrderByDescending(d => d.Followers).Take(count).ToList();
        }
    }
}
