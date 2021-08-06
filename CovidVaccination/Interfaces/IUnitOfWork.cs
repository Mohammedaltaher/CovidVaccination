using System;
using System.Collections.Generic;
using System.Text;

namespace CovidVaccination.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVaccinationRepository Vaccinations { get; }
        IPatientRepository Patients { get; }
        int Complete();
    }
}
