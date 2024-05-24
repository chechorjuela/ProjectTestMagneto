using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Domain.Entities
{
    public class Measurement
    {
        public int Id {  get; set; }
        public int DeviceId { get; set; }
        public DateTime EventProcessed { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Value { get; set; }
        public int UserId {  get; set; }
        public Device Device {  get; set; }
        public User User { get; set; }


    }
}
