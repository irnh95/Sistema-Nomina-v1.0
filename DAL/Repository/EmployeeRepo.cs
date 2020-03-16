using DAL.Entities;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repository
{
    public class EmployeeRepo : Repository<Employee>
    {
        public EmployeeRepo(ApplicationDbContext context) : base(context)
        {
        }

        public Employee GetByEmail(string email)
        {
            return dbSet.FirstOrDefault(employee => employee.Email == email);
        }
    }
}
