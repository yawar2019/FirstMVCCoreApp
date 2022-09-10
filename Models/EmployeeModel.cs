using System.ComponentModel.DataAnnotations;

namespace FirstMVCCoreApp.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
        public int des { get; set; }
    }
}
