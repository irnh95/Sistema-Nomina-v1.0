using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.ViewModels;
using DAL.Entities;
using DAL.UnitWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Logic
{
    public class EmployeeLogic : Logic
    {
        private readonly UserManager<Employee> _userManager;
        public EmployeeLogic(IMapper mapper, UserManager<Employee> useManager) : base(mapper)
        {
            _userManager = useManager;
        }

        public IEnumerable<EmployeeVM> GetEmployees()
        {
            try
            {
                return _mapper.Map<List<EmployeeVM>>(_unitWork.Employee.Get());
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public bool isEmployeeActive(string email)
        {
            try
            {
                Employee employee = _unitWork.Employee.Get(filter: x => x.Email == email).FirstOrDefault();
                return employee != null ? employee.Activo : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IdentityResult Register(EmployeeVM employeeVM)
        {
            return _userManager.CreateAsync(_mapper.Map<Employee>(employeeVM), employeeVM.Password).Result;
        }
    }
}
