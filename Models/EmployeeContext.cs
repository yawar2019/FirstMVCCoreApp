using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FirstMVCCoreApp.Models
{
    public class EmployeeContext:DbContext
    {
        
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
          
        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
    }
}
