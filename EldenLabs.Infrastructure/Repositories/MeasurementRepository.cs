using EldenLabs.Domain.Entities;
using EldenLabs.Domain.Repositories;
using EldenLabs.Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Infrastructure.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly AppDbContext _context;

        public MeasurementRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Measurement>> GetAllMeasurenmentByUser(int UserId)
        {
            return await _context.Measurements.Where(m => m.UserId == UserId).ToListAsync();
        }
    }
}
