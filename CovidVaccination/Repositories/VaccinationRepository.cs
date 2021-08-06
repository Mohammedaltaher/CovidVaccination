using CovidVaccination.Interfaces;
using CovidVaccination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace CovidVaccination.Repositories
{
    public class VaccinationRepository : GenericRepository<Vaccination>, IVaccinationRepository
    {
        public VaccinationRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Vaccination> GetAllVaccinations()
        {
            return _context.Vaccinations.Include(x=>x.Patient);
        }
    }
}
