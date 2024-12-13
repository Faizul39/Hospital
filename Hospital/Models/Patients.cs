using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Patients
    {
        [Display(Name = "ID")]
        [Key]
        public int PatientId { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Age")]
        [Required]
        public int Age { get; set; }
        [Display(Name = "Clinic ID")]
        [Required]
        public int ClinicId { get; set; }
        [Display(Name = "Created Date")]
        [Required]
        public DateTime Created_Date { get; set; }
        public enum Status { Active, Inactive, }
        public Clinic Clinic { get; set; }
    }
}
