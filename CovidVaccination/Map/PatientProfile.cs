using AutoMapper;
using CovidVaccination.Model;
using CovidVaccination.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination.Map
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {

            CreateMap<Vaccination, PatientVaccination>()
                .ForMember(dest => dest.VaccinationName, opt => opt.MapFrom(src => src.Name));
            CreateMap<PatientRequest, Patient>();
            CreateMap<Patient, PatientData>()
                 .ForMember(dest => dest.Vaccinations, opt => opt.MapFrom(src => src.Vaccinations)); ;
            CreateMap<Patient, PatientResponse>();

        }
    }
}
