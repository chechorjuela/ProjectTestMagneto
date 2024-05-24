using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string NameDevice { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User User { get; set; }
        public ICollection<Measurement> Measurements { get; set; }
    }
}
