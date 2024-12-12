namespace Hospital.Models
{
    public class Patients
    {
        public int Patient_Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Clinic_Id { get; set; }
        public DateTime Created_Date { get; set; }
        public string Status { get; set; }
    }
}
