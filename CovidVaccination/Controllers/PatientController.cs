using AutoMapper;
using CovidVaccination.Interfaces;
using CovidVaccination.Model;
using CovidVaccination.ViewModel;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PatientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetById")]
        public PatientResponse GetById(int PatientId)
        {
            try
            {
                var PatientDb = _unitOfWork.Patients.GetById(PatientId);

                if (PatientDb == null)
                    return new PatientResponse
                    {
                        Data = null,
                        Code = 404,
                        Message = "Patient Not Found"

                    };
                return new PatientResponse
                {
                    Data = _mapper.Map<Patient, PatientData>(PatientDb),
                    Code = 200,
                    Message = "Patient Has been Found"

                };
            }
            catch (Exception ex)
            {
                return new PatientResponse
                {
                    Data = null,
                    Code = 500,
                    Message = ex.Message

                };
            }
        }

        [HttpPost]
        [Route("Add")]
        public BaseResponse Add(PatientRequest req)
        {
            try
            {
                var patient = _mapper.Map<PatientRequest, Patient>(req);

                _unitOfWork.Patients.Add(patient);

                _unitOfWork.Complete();
                return new BaseResponse
                {
                    Code = 200,
                    Message = "Patient Added Successfully"

                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Code = 500,
                    Message = ex.Message

                };
            }
        }

        [HttpPut]
        [Route("Update")]
        public BaseResponse Update(int PatientId, PatientRequest req)
        {
            try
            {
                var PatientDb = _unitOfWork.Patients.GetById(PatientId);
                if (PatientDb == null)
                    return new BaseResponse
                    {
                        Code = 404,
                        Message = "Patient Not Found"

                    };
                _mapper.Map<PatientRequest, Patient>(req, PatientDb);

                _unitOfWork.Complete();

                return new BaseResponse
                {
                    Code = 200,
                    Message = "Patient Updated Successfully"

                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Code = 500,
                    Message = ex.Message

                };
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public BaseResponse Delete(int PatientId)
        {
            try
            {
                var PatientDb = _unitOfWork.Patients.GetById(PatientId);
                if (PatientDb == null)
                    return new BaseResponse
                    {
                        Code = 402,
                        Message = "Patient Not Found"
                    };
                _unitOfWork.Patients.Remove(PatientDb);
                _unitOfWork.Complete();
                return new BaseResponse
                {
                    Code = 200,
                    Message = "Patient deleted Successfully"

                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Code = 500,
                    Message = ex.Message

                };
            }
        }
    }
}