using AutoMapper;
using EldenLabs.Application.Core.Dto;
using EldenLabs.Application.Core.Dto.Response;
using EldenLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            // Dto Response
            CreateMap<Measurement, MeasurementResponseDto>();
            CreateMap<User, SignInResponseDto>();
            CreateMap<User, SignUpResponseDto>();

            // Dtos request
            CreateMap<MeasurementRequestDto, Measurement>();
            CreateMap<SignUpRequestDto, User>();
            CreateMap<SignInRequestDto, User>();
        }
    }
}
