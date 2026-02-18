using Hms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hms.Infrastructure.Data
{
    public class HmsDbContext :DbContext
    {
        public HmsDbContext(DbContextOptions<HmsDbContext> options) :base(options)
        {
            
        }

        public DbSet<Doctor> DBDoctors { get; set; }
    }
}
