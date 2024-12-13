using Hospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Patients> patient { get; set; }
        public virtual DbSet<Clinic> clinic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>().HasMany(c => c.Patients).WithOne(p => p.Clinic).HasForeignKey(p => p.ClinicId);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        }
    }
     
}
