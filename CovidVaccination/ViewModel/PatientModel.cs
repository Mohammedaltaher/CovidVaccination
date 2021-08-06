using CovidVaccination.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination.ViewModel
{
    public class PatientRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }

    public class PatientData : PatientRequest
    {
        public DateTime DateOfRegistration { get; set; }
        public bool VaccinationStatus { get; set; }
        public IEnumerable<PatientVaccination> Vaccinations { get; set; }

    }
    public class PatientVaccination 
    {
        public DateTime Date { get; set; }
        public string VaccinationName { get; set; }
    }
    public class PatientResponse : BaseResponse
    {
        public PatientData Data { get; set; }

    }
    public class PatientsResponse : BaseResponse
    {
        public List<PatientData> Data { get; set; }

    }
    public class PatientRequestValidator : AbstractValidator<PatientRequest>
    {
        public PatientRequestValidator()
        {
           
            RuleSet("PatientRule", () =>
            {
                RuleFor(x => x.Name).NotNull().WithMessage("Name could not be null");
                RuleFor(x => x.Address).NotNull().WithMessage("Address could not be null");
                RuleFor(x => x.Email).NotNull().WithMessage("Email could not be null");
                RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
                RuleFor(x => x.DateOfBirth).NotNull().WithMessage("Date Of Birth could not be null");
                RuleFor(x => x.DateOfBirth).Must(BeAValidDate).WithMessage("Date Of Birth  is not valid Date");
            });
        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

    }
}
