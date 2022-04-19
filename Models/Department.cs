using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        public string DepName { get; set; }
        public IList<Personnel> Personnels { get; set; }
    }
}
