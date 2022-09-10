using FirstMVCCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Repsitory
{
    public class EmployeeRepsoitory:IEmployeeRepository
    {
        public EmployeeContext _employeeContext;
        public EmployeeRepsoitory(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public List<EmployeeModel> GetEmployees()
        {
            return _employeeContext.EmployeeModels.ToList();
        }
    }
}
