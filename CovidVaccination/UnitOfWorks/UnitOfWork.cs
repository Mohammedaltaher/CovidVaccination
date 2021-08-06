using CovidVaccination.Repositories;
using CovidVaccination.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CovidVaccination.Model;

namespace CovidVaccination.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Vaccinations = new VaccinationRepository(_context);
            Patients = new PatientRepository(_context);
        }
        public IVaccinationRepository Vaccinations { get; private set; }
        public IPatientRepository Patients { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
