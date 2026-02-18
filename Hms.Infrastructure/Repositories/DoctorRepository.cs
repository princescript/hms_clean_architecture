using Hms.Domain.Entities;
using Hms.Domain.Interfaces;
using Hms.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hms.Infrastructure.Repositories
{
    public class DoctorRepository :IDoctorRepository
    {
        private readonly HmsDbContext _context;
        public DoctorRepository(HmsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.DBDoctors.ToListAsync();
        }
        public async Task<Doctor?> GetByIdAsync(int id) 
        {
            return await _context.DBDoctors.FindAsync(id);
        }

        public async Task Create (Doctor doctor)
        {
           await _context.DBDoctors.AddAsync(doctor);
           await _context.SaveChangesAsync();
        
        }
        public async Task Update(Doctor doctor)
        {
            _context.DBDoctors.Update(doctor);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Doctor doctor)
        {
            _context.DBDoctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

    }
}
