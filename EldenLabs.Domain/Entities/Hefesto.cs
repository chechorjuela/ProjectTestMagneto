using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Domain.Entities
{
    public class Hefesto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HefestoId { get; set; }
        public ICollection<Measurement> Measurements { get; set; }
    }
}
