using DAL.Entities;
using DAL.Data;
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
