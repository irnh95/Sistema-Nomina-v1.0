using DAL.Entities;
using Sistema_Nomina_v1._0.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRepo : Repository<Employee<int>>
    {
        public EmployeeRepo(ApplicationDbContext context) : base(context)
        {
        }

    }
}
