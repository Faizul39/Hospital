using Hospital.Models;
using Microsoft.Data.SqlClient;

namespace Hospital.Interface
{
    public interface IClinic
    {
        List<Clinic> GetAllClinic();
        Clinic GetClinicById(int id);
        Clinic AddClinic(Clinic cln);
        Clinic UpdateClinic(Clinic ucln);
        Clinic Details(int id);
        void DeleteClinic(int id);
    }
}
