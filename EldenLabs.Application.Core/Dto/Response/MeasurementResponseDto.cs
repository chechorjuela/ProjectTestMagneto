using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Dto.Response
{
    public class MeasurementResponseDto
    {
        public int Id { get; set; }
        public string ConnectionDeviceId { get; set; }
        public DateTime EventProcessedUtcTime {  get; set; }
        public string HefestoId {  get; set; }
        public DateTime Timestamp { get; set; }
        public string VarName { get; set; }
        public int Value { get; set; }
        public string Plugin { get; set; }
        public string Request {  get; set; }
        public string VarNameSecond { get; set; }
        public int Device { get; set; }
    }
}
