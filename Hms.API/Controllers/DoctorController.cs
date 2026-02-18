using Azure;
using Hms.Application.Dtos;
using Hms.Application.Interfaces;
using Hms.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Hms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _services;
        public DoctorController(IDoctorServices services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAllAsync()
        {
            var doctors = await _services.GetAllAsync();

            if (doctors == null || !doctors.Any())
            {
                return Ok(new Response
                {
                    Code = 200,
                    Success = false,
                    Message = "Doctors not  found.",
                    Data = null,
                    Pagination = null,

                });
            }
            return Ok(new Response
            {
                Code = 200,
                Message = "Doctors fetched successfully.",
                Success = true,
                Data = doctors,
                Pagination = null

            });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DoctorDto?>> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new Response
                {
                    Code = 400,
                    Success = false,
                    Message = "Invalid doctor id",
                    Data = null,
                    Pagination = null
                });
            }

            var doctor = await _services.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound(new Response
                {
                    Code = 404,
                    Success = false,
                    Message = "Doctor not found",
                    Data = null,
                    Pagination = null
                });
            }

            return Ok(new Response
            {
                Code = 201,
                Message = "Doctors fetched successfully.",
                Success = true,
                Data = doctor,
                Pagination = null

            });
        }
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateAsync(DoctorDto entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    Code = 400,
                    Success = false,
                    Message = "Invalid doctor id",
                    Data = null,
                    Pagination = null
                });
            }
            var createdDoctor = await _services.CreateAsync(entity);
            entity.DocId = createdDoctor.DocId;

            return Ok(new Response
            {
                Code = 200,
                Success = true,
                Message = "Doctor created successfully.",
                Data = entity,
                Pagination = null
            });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DoctorDto>> UpdateAsync([FromBody] DoctorDto dto)
        {
            var doctor = await _services.UpdateAsync(dto);
            return Ok(new Response
            {
                Code = 200,
                Message = "Doctors Updated successfully.",
                Success = true,
                Data = doctor,
                Pagination = null

            });
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DoctorDto>> DeleteByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new Response
                {
                    Code = 400,
                    Message = "Invalid doctor id.",
                    Success = false,
                    Data = null,
                    Pagination = null

                });
                    
            }
            var doctor = await _services.DeleteByIdAsync(id);
            return Ok(new Response
            {
                Code = 200,
                Message = "Doctors Deleted successfully.",
                Success = true,
                Data = doctor,
                Pagination = null

            });
        }
    }
}