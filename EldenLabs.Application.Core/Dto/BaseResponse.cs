using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Dto
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }


}
