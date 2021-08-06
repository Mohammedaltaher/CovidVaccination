using CovidVaccination.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination.ViewModel
{
    public class VaccinationRequest
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
    }

    public class VaccinationData : VaccinationRequest
    {
        public DateTime Date { get; set; }
        public string PatientName { get; set; }

    }
    public class VaccinationResponse : BaseResponse
    {
        public VaccinationData Data { get; set; }

    }
    public class VaccinationsResponse : BaseResponse
    {
        public List<VaccinationData> Data { get; set; }

    }
    public class VaccinationRequestValidator : AbstractValidator<VaccinationRequest>
    {
        public VaccinationRequestValidator()
        {
           
            RuleSet("VaccinationRule", () =>
            {
                RuleFor(x => x.Name).NotNull().WithMessage("Name could not be null");
                RuleFor(x => x.PatientId).NotNull().WithMessage("PatientId could not be null");
            });
        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

    }
}
