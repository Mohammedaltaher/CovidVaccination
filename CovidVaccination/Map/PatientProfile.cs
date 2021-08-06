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
           
            CreateMap<PatientRequest, Patient>();
            CreateMap<Patient, PatientData>();
            CreateMap<Patient, PatientResponse>();

        }
    }
}
