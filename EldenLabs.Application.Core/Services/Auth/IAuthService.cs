using EldenLabs.Application.Core.Dto;
using EldenLabs.Application.Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Services
{
    public interface IAuthService
    {
        public Task<BaseResponse<SignInResponseDto>> SignIn(SignInRequestDto signInRequest);
        public Task<BaseResponse<SignUpResponseDto>> SignUp(SignUpRequestDto signUpRequest);
    }
}
