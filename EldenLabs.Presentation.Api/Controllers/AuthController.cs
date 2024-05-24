using EldenLabs.Application.Core.Dto;
using EldenLabs.Application.Core.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldenLabs.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        private readonly IValidator<SignInRequestDto> _signInValidator;
        private readonly IValidator<SignUpRequestDto> _signUpValidator;

        public AuthController(
            IAuthService authService,
        IValidator<SignInRequestDto> signInValidator,
            IValidator<SignUpRequestDto> signUpValidator)
        {
            _authService = authService;
            _signInValidator = signInValidator;
            _signUpValidator = signUpValidator;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDto signInRequest)
        {

            ValidationResult validationResult = _signInValidator.Validate(signInRequest);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _authService.SignIn(signInRequest);

            return Ok(result);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto signUpRequest)
        {

            ValidationResult validationResult = _signUpValidator.Validate(signUpRequest);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _authService.SignUp(signUpRequest);

            return Ok(result);
        }
    }
}
