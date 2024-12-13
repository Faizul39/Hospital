using Hospital.Data;
using Hospital.Interface;
using Hospital.Models;

namespace Hospital.Repository
{
    public class PatientRepository : IPatient
    {
        private readonly ApplicationDbContext _ctx;
        public PatientRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Patients> GetAllPatient()
        {
            List<Patients> ptns = _ctx.patient.ToList();
            return ptns;
        }

        public Patients GetPatientById(int id)
        {
            Patients ptns = _ctx.patient.FirstOrDefault(p => p.PatientId == id);
            return ptns;
        }

        public Patients AddPatient(Patients psnt)
        {
            _ctx.patient.Add(psnt);
            _ctx.SaveChanges();
            return psnt;
        }

        public Patients UpdatePatient(Patients upsnt)
        {
            Patients ptns = _ctx.patient.FirstOrDefault(p => p.PatientId == upsnt.PatientId);
            ptns.PatientId = upsnt.PatientId;
            ptns.Name = upsnt.Name;
            ptns.Age = upsnt.Age;
            ptns.ClinicId = upsnt.ClinicId;
            ptns.Created_Date = upsnt.Created_Date;
            _ctx.SaveChanges();
            return upsnt;
        }

        public Patients Details(int id)
        {
            Patients ptns = _ctx.patient.FirstOrDefault(c => c.PatientId == id);
            return ptns;
        }

        public void DeletePatient(int id)
        {
            Patients delptns = _ctx.patient.FirstOrDefault(c => c.PatientId == id);
            if (delptns != null)
            {
                _ctx.patient.Remove(delptns);
                _ctx.SaveChanges();
            }
        }
    }
}
