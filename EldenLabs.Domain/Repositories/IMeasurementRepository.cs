using EldenLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Domain.Repositories
{
    public interface IMeasurementRepository
    {
        public Task<List<Measurement>> GetAllMeasurenmentByUser(int UserId);
    }
}
