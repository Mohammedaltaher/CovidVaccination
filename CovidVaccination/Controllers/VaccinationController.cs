using AutoMapper;
using CovidVaccination.Interfaces;
using CovidVaccination.Model;
using CovidVaccination.ViewModel;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VaccinationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetById")]
        public VaccinationResponse GetById(int VaccinationId)
        {
            try
            {
                var VaccinationDb = _unitOfWork.Vaccinations.GetById(VaccinationId);

                if (VaccinationDb == null)
                    return new VaccinationResponse
                    {
                        Data = null,
                        Code = 404,
                        Message = "Vaccination Not Found"

                    };
                return new VaccinationResponse
                {
                    Data = _mapper.Map<Vaccination, VaccinationData>(VaccinationDb),
                    Code = 200,
                    Message = "Vaccination Has been Found"

                };
            }
            catch (Exception ex)
            {
                return new VaccinationResponse
                {
                    Data = null,
                    Code = 500,
                    Message = ex.Message

                };
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public VaccinationsResponse GetAll()
        {
            try
            {
                var VaccinationDb = _unitOfWork.Vaccinations.GetAllVaccinations();

                if (VaccinationDb == null)
                    return new VaccinationsResponse
                    {
                        Data = null,
                        Code = 404,
                        Message = "No Vaccinations Yet"

                    };
                return new VaccinationsResponse
                {
                    Data = _mapper.Map<IEnumerable<Vaccination>, List<VaccinationData>>(VaccinationDb),
                    Code = 200,
                    Message = "Vaccinations Has been Loaded"

                };
            }
            catch (Exception ex)
            {
                return new VaccinationsResponse
                {
                    Data = null,
                    Code = 500,
                    Message = ex.Message

                };
            }
        }
        [HttpPost]
        [Route("Add")]
        public BaseResponse Add([CustomizeValidator(RuleSet = "VaccinationRule")] VaccinationRequest req)
        {
            try
            {
                var Vaccination = _mapper.Map<VaccinationRequest, Vaccination>(req);
                var PatientDb = _unitOfWork.Patients.GetById(req.PatientId);
                PatientDb.VaccinationStatus = true;

                _unitOfWork.Vaccinations.Add(Vaccination);
                _unitOfWork.Complete();

                return new BaseResponse
                {
                    Code = 200,
                    Message = "Vaccination Added Successfully"

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
        public BaseResponse Update(int VaccinationId, VaccinationRequest req)
        {
            try
            {
                var VaccinationDb = _unitOfWork.Vaccinations.GetById(VaccinationId);
                if (VaccinationDb == null)
                    return new BaseResponse
                    {
                        Code = 404,
                        Message = "Vaccination Not Found"

                    };
                _mapper.Map<VaccinationRequest, Vaccination>(req, VaccinationDb);

                _unitOfWork.Complete();

                return new BaseResponse
                {
                    Code = 200,
                    Message = "Vaccination Updated Successfully"

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
        public BaseResponse Delete(int VaccinationId)
        {
            try
            {
                var VaccinationDb = _unitOfWork.Vaccinations.GetById(VaccinationId);
                if (VaccinationDb == null)
                    return new BaseResponse
                    {
                        Code = 402,
                        Message = "Vaccination Not Found"
                    };
                _unitOfWork.Vaccinations.Remove(VaccinationDb);
                _unitOfWork.Complete();
                return new BaseResponse
                {
                    Code = 200,
                    Message = "Vaccination deleted Successfully"

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