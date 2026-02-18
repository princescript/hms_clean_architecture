using Hms.Application.Dtos;

namespace Hms.Application.Interfaces
{
    public interface IDoctorServices
    {
        Task<List<DoctorDto>> GetAllAsync();
        Task<DoctorDto?> GetByIdAsync(int id);
        Task<DoctorDto> CreateAsync(DoctorDto dto);
        Task<DoctorDto?> UpdateAsync(DoctorDto dto);
        Task<DoctorDto?> DeleteByIdAsync(int id);
    }
}
