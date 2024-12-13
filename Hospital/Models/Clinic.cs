using Hospital.Interface;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Clinic
    {
        [Display(Name = "ID")]
        [Key]
        public int  ClinicId  { get; set; }
        
        [Display(Name = "Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Address")]
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        public enum Status { Active, Inactive }
        [Display(Name = "Created Date")]
        [Required]
        public DateTime Created_Date { get; set; }
        public ICollection<Patients> Patients { get; set; }
    }
}
