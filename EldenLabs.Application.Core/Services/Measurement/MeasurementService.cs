using AutoMapper;
using EldenLabs.Application.Core.Dto;
using EldenLabs.Application.Core.Dto.Response;
using EldenLabs.Domain.Entities;
using EldenLabs.Domain.Repositories;
using EldenLabs.Domain.Repositories.Base;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EldenLabs.Application.Core.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly IUnitOfWork<Measurement> _unitOfWork;
        private readonly IMapper _mapper;
        public MeasurementService(
            IMeasurementRepository measurementRepository,
            IUnitOfWork<Measurement> unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _measurementRepository = measurementRepository;
        }
        public async Task<BaseResponse<MeasurementResponseDto>> CreateMeasurement(MeasurementRequestDto measurementRequest)
        {
            Measurement measurement = _mapper.Map<Measurement>(measurementRequest);
            var measurementResponse = await _unitOfWork.Repository.AddAsync(measurement);
            await _unitOfWork.SaveChangesAsync();
            BaseResponse<MeasurementResponseDto> response = new BaseResponse<MeasurementResponseDto>()
            {
                Data = _mapper.Map<MeasurementResponseDto>(measurementResponse),
                Message = "Measurenment Save succesfull"
            };

            return response;
        }

        public async Task<BaseResponse<List<MeasurementResponseDto>>> GetAllMeasurenment()
        {
            var measurementResponse = await _unitOfWork.Repository.GetAllAsync();
            BaseResponse<List<MeasurementResponseDto>> response = new BaseResponse<List<MeasurementResponseDto>>()
            {
                Data = _mapper.Map<List<MeasurementResponseDto>>(measurementResponse),
                Message = "Get all measurenment"
            };
            return response;


        }

        public async Task<BaseResponse<List<MeasurementResponseDto>>> GetAllMeasurenmentByUser(int userId)
        {
           var measurenmentList = await _measurementRepository.GetAllMeasurenmentByUser(userId);

            BaseResponse<List<MeasurementResponseDto>> response = new BaseResponse<List<MeasurementResponseDto>>()
            {
                Data = _mapper.Map<List<MeasurementResponseDto>>(measurenmentList),
                Message = "Get all measurenment By UserId"
            };
            return response;
        }

        public async Task<BaseResponse<MeasurementResponseDto>> GetById(int id)
        {
            var measurementResponse = await _unitOfWork.Repository.GetByIdAsync(id);
            BaseResponse<MeasurementResponseDto> response = new BaseResponse<MeasurementResponseDto>()
            {
                Data = _mapper.Map<MeasurementResponseDto>(measurementResponse),
                Message = "Measurenment saved succesfull"
            };

            return response;
        }

        public async Task<BaseResponse<MeasurementResponseDto>> UpdateMeasurement(int id, MeasurementRequestDto measurementRequest)
        {
            Measurement measurement = _mapper.Map<Measurement>(measurementRequest);
            var measurementResponse = await _unitOfWork.Repository.UpdateAsync(measurement);
            await _unitOfWork.SaveChangesAsync();
            BaseResponse<MeasurementResponseDto> response = new BaseResponse<MeasurementResponseDto>()
            {
                Data = _mapper.Map<MeasurementResponseDto>(measurementResponse),
                Message = "Measurenment ppdated succesfull"
            };

            return response;
        }
    }
}
