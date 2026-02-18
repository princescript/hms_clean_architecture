using Hms.Application.Dtos;
using Hms.Application.Interfaces;
using Hms.Domain.Entities;
using Hms.Domain.Interfaces;

namespace Hms.Application.Services
{
    public class DoctorServices :IDoctorServices
    {
        private readonly IDoctorRepository _repository;
        public DoctorServices(IDoctorRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DoctorDto>> GetAllAsync()
        {
            var doctors = await _repository.GetAllAsync();

            return doctors.Select(x => new DoctorDto {
                DocId = x.DocId,
                DocName = x.DocName,
                DocPhone   = x.DocPhone,
                DocSpecialization = x.DocSpecialization
            }).ToList();
        }
        public async Task<DoctorDto?> GetByIdAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor == null)
                return null;

            return new DoctorDto
            {
                DocId = doctor.DocId,
                DocName = doctor.DocName,
                DocPhone = doctor.DocPhone,
                DocSpecialization = doctor.DocSpecialization
            };
        }

        public async Task<DoctorDto> CreateAsync(DoctorDto dto)
        {
            
            var doctor = new Doctor
            {
                DocId = dto.DocId,
                DocName = dto.DocName,
                DocPhone = dto.DocPhone,
                DocSpecialization = dto.DocSpecialization
            };
            await _repository.Create(doctor);
            dto.DocId = doctor.DocId;
            return dto;
        }
        public async Task<DoctorDto?> UpdateAsync(DoctorDto dto)
        {
            var doctor = await _repository.GetByIdAsync(dto.DocId);
            if (doctor == null) return null;

            doctor.DocName = dto.DocName;
            doctor.DocPhone = dto.DocPhone;
            doctor.DocSpecialization = dto.DocSpecialization;

           await _repository.Update(doctor);
            return dto;

        }
        public async Task<DoctorDto?> DeleteByIdAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if(doctor == null) return null;
            await _repository.DeleteByIdAsync(doctor);

            return new DoctorDto
            {
                DocId = doctor.DocId,
                DocName = doctor.DocName,
                DocPhone = doctor.DocPhone,
                DocSpecialization = doctor.DocSpecialization
            };

        }
    }
}
