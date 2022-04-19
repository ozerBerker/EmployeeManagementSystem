using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Personnel
    {
        [Key]
        public int PersId { get; set; }
        //public int PersAge { get; set; }
        public string? PersName { get; set; }

        //public string? PersSurname { get; set; }
        //public string? PersAddress { get; set; }
        //public string? PersPhone { get; set; }
        //public bool PersActive { get; set; }

        //Relative with deparments class 
        public int DepId { get; set; }
        public Department? Department { get; set; }


    }
}
