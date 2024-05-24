using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Dto
{
    public class MeasurementRequestDto
    {
        public string DeviceId { get; set; }
        public string HefestoId {  get; set; }
        public string VarName {  get; set; }
        public int Value { get; set; }
        public string Plugin {  get; set; }
        public string Request { get;set; }
        public string VarNameSecond {  get; set; }

    }
}
