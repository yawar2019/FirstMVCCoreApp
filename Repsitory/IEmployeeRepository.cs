using FirstMVCCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Repsitory
{
    public interface IEmployeeRepository
    {
        public List<EmployeeModel> GetEmployees();
    }
}
