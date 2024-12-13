using Hospital.Data;
using Hospital.Interface;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository
{
    public class ClinicRepository : IClinic
    {
        private readonly ApplicationDbContext _ctx;
        public ClinicRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Clinic> GetAllClinic()
        {
            List<Clinic> clns = _ctx.clinic.ToList();
            return clns;
        }

        public Clinic GetClinicById(int id)
        {
            Clinic cln = _ctx.clinic.FirstOrDefault(c => c.ClinicId == id);
            return cln;
        }

        public Clinic AddClinic(Clinic cln)
        {
            _ctx.clinic.Add(cln);
            _ctx.SaveChanges();
            return cln;
        }

        public Clinic UpdateClinic(Clinic ucln)
        {
            Clinic cln = _ctx.clinic.FirstOrDefault(c => c.ClinicId == ucln.ClinicId);
            cln.ClinicId = ucln.ClinicId;
            cln.Name = ucln.Name;
            cln.Address = ucln.Address;
            cln.Created_Date = ucln.Created_Date;
            _ctx.SaveChanges();
            return ucln;
        }

        public Clinic Details(int id)
        {
            Clinic cln = _ctx.clinic.FirstOrDefault(c => c.ClinicId == id);
            return cln;
        }
        public void DeleteClinic(int id)
        {
            Clinic delclns = _ctx.clinic.FirstOrDefault(p => p.ClinicId == id);
            if (delclns != null)
            {
                _ctx.clinic.Remove(delclns);
                _ctx.SaveChanges();
            }
        } 
    }
}
