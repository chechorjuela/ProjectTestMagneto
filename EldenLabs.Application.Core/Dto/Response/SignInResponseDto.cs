using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Dto.Response
{
    public class SignInResponseDto
    {
        public UserResponseDto UserInfo { get; set; }
        public string Token { get; set; }
        public DateTime DateExperition {  get; set; }
        public string RefreshToken { get; set; }
    }
}
