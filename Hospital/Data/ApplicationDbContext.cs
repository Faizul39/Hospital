using Hospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Patients> patient { get; set; }
        public virtual DbSet<Clinic> clinic { get; set; }
    }
}
