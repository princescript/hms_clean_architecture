using Hms.Domain.Entities;

namespace Hms.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task Create(Doctor doctor);
        Task Update (Doctor doctor);
        Task DeleteByIdAsync(Doctor doctor);
    }
}
