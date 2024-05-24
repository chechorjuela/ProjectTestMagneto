using AutoMapper;
using EldenLabs.Application.Core.Dto;
using EldenLabs.Application.Core.Dto.Response;
using EldenLabs.Domain.Entities;
using EldenLabs.Domain.Repositories;
using EldenLabs.Domain.Repositories.Base;
using EldenLabs.Infrastructure.Helpers.Jwt;

namespace EldenLabs.Application.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork<User> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtTokenService _jwtTokenService;

        public AuthService(
            IUserRepository userRepository,
            IUnitOfWork<User> unitOfWork,
            JwtTokenService jwtTokenService,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;

        }

        public async Task<BaseResponse<SignInResponseDto>> SignIn(SignInRequestDto signInRequest)
        {
            BaseResponse<SignInResponseDto> response = new BaseResponse<SignInResponseDto>();
            User userMapper = _mapper.Map<User>(signInRequest);
            var userFind = await _userRepository.SignInUser(userMapper);
            if (userFind==null) {
                response.Message = "User not exist. please try with your username correct!";
                return response;
            }
            if (!BCrypt.Net.BCrypt.Verify(signInRequest.Password, userFind.Password))
            {
                response.Message = "Your password is incorrrect. Please Check the password";
                return response;
            }
            var userResponse = _mapper.Map<SignInResponseDto>(userFind);
            userResponse.Token = _jwtTokenService.GenerateToken(userFind);
            response.Data = userResponse;
            return response;
        }

        public async Task<BaseResponse<SignUpResponseDto>> SignUp(SignUpRequestDto signUpRequest)
        {
            BaseResponse<SignUpResponseDto> response = new BaseResponse<SignUpResponseDto>();
            var userMapper = _mapper.Map<User>(signUpRequest);
            var existUser = await _userRepository.ExistUserByUsername(userMapper.UserName);
            if (existUser) {
                response.Message = "User already exist";
                return response;
            }

            userMapper.Password = BCrypt.Net.BCrypt.HashPassword(userMapper.Password);
            var result = await _unitOfWork.Repository.AddAsync(userMapper);
            await _unitOfWork.SaveChangesAsync();
            SignUpResponseDto signResponse = _mapper.Map<SignUpResponseDto>(result);
            response.Data = signResponse;
            response.Message = "User Sign Up success.";
            return response;

        }
    }
}
