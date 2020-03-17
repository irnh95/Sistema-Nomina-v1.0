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

        public IEnumerable<Employee> GetMonthPayRoll()
        {
            return dbSet.Where(employee => employee.Activo
                && employee.FechaIngreso.Year == DateTime.Now.Year
                && employee.FechaIngreso.Month == DateTime.Now.Month).ToList();
        }

        public Employee GetEmployeeMonthlyPayRoll(int id)
        {
            return dbSet.Find(id);
        }
    }
}
