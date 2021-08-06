using AutoMapper;
using CovidVaccination.Model;
using CovidVaccination.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination.Map
{
    public class VaccinationProfile : Profile
    {
        public VaccinationProfile()
        {
           
            CreateMap<VaccinationRequest, Vaccination>();
            CreateMap<Vaccination, VaccinationData>()
                                 .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name)); ; ;
            CreateMap<Vaccination, VaccinationResponse>();


        }
    }
}
