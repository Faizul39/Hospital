using Hospital.Models;

namespace Hospital.Interface
{
    public interface IPatient
    {
        List<Patients> GetAllPatient();
        Patients GetPatientById(int id);
        Patients AddPatient(Patients psnt);
        Patients UpdatePatient(Patients upsnt);
        Patients Details(int id);
        void DeletePatient(int id);
    }
}
