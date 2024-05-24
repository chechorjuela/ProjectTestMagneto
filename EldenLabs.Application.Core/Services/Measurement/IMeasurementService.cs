using EldenLabs.Application.Core.Dto.Response;
using EldenLabs.Application.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Services
{
    public interface IMeasurementService
    {
        Task<BaseResponse<MeasurementResponseDto>> CreateMeasurement(MeasurementRequestDto measurementRequest);
        Task<BaseResponse<MeasurementResponseDto>> GetById(int id);
        Task<BaseResponse<List<MeasurementResponseDto>>> GetAllMeasurenment();
        Task<BaseResponse<List<MeasurementResponseDto>>> GetAllMeasurenmentByUser(int userId);
        Task<BaseResponse<MeasurementResponseDto>> UpdateMeasurement(int id, MeasurementRequestDto measurementRequest);

    }
}
