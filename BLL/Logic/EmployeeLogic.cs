﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.ViewModels;
using DAL.Entities;
using DAL.UnitWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        /// <summary>
        /// This method is only for test purposes
        /// </summary>
        public void CreateFirstAdmin()
        {
            try
            {
                if (!_unitWork.Employee.Get().Any())
                {
                    Create(new EmployeeVM() { 
                        Activo = true,
                        Nombre = "Admin",
                        ApellidoPaterno = "Test",
                        ApellidoMaterno = "User",
                        Base = 0,
                        DeduccionAhorro = 0,
                        DeduccionDesayuno = 0,
                        DeduccionGasolina = 0,
                        Email = "admin@test.user",
                        Password = "TestUser1!",
                        FechaIngreso = DateTime.Now,
                    });
                    IdentityRole<int> role = new IdentityRole<int>() { Name = "Admin" };
                    _unitWork.Role.Add(role);
                    Commit();

                    int id = GetEmployeIdByEmail("admin@test.user");
                    AddRoles(id, new int[] { role.Id });
                    Commit();
                }
            }
            catch(Exception e) { }
        }

        // methods for employees
        public IEnumerable<EmployeeVM> GetEmployees()
        {
            try
            {
                return _mapper.Map<List<EmployeeVM>>(_unitWork.Employee.Get().OrderByDescending(x => x.FechaIngreso));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public EmployeeVM GetEmployeById(int id)
        {
            EmployeeVM employeeVM = _mapper.Map<EmployeeVM>(_unitWork.Employee.GetByID(id));
            employeeVM.employeeRoleId = _unitWork.EmployeeRole.Get(X => X.UserId == id).Select(x => x.RoleId).ToList();
            return employeeVM;
        }

        public EmployeeVM GetEmployeByEmail(string email)
        {
            return _mapper.Map<EmployeeVM>(_unitWork.Employee.GetByEmail(email));
        }


        public int GetEmployeIdByEmail(string email)
        {
            return _unitWork.Employee.GetByEmail(email).Id;
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
        public IdentityResult Create(EmployeeVM employeeVM)
        {
            IdentityResult result = _userManager.CreateAsync(_mapper.Map<Employee>(employeeVM), employeeVM.Password == null ? "Tememp123!" : employeeVM.Password).Result;
            if (result.Succeeded && employeeVM.Password == null)
            {
                _userManager.RemovePasswordAsync(_unitWork.Employee.GetByEmail(employeeVM.Email));
            }
            return result;
        }

        public void Update(EmployeeVM employeeVM)
        {
            Employee employee = _unitWork.Employee.GetByID(employeeVM.Id);


            // guarantee only happen to specified details
            employee.Activo = employeeVM.Activo;
            employee.ApellidoMaterno = employeeVM.ApellidoMaterno;
            employee.ApellidoPaterno = employeeVM.ApellidoPaterno;
            employee.Base = employeeVM.Base;
            employee.DeduccionAhorro = employeeVM.DeduccionAhorro;
            employee.DeduccionDesayuno = employeeVM.DeduccionDesayuno;
            employee.DeduccionGasolina = employeeVM.DeduccionGasolina;
            employee.Email = employeeVM.Email;
            employee.FechaBaja = employeeVM.FechaBaja;
            employee.FechaIngreso = employeeVM.FechaIngreso;
            employee.Nombre = employeeVM.Nombre;

            // change employee data
            _unitWork.Employee.update(employee);

            //reset password
            if (!String.IsNullOrEmpty(employeeVM.Password))
            {
                string token = _userManager.GeneratePasswordResetTokenAsync(employee).Result;
                _userManager.ResetPasswordAsync(employee, token, employeeVM.Password);
            }
        }
        public void SwitchStatus(int id)
        {
            Employee employee = _unitWork.Employee.GetByID(id);
            employee.employeeRole = null;
            if (employee.Activo)
            {
                employee.FechaBaja = DateTime.Now.Date;
            }
            employee.Activo = !employee.Activo;

            _unitWork.Employee.update(employee);
        }

        // methods for Roles
        public void DeleteEmployeeRoles(int employeeId)
        {
            _unitWork.EmployeeRole.DeleteBatch(_unitWork.EmployeeRole.Get(x => x.UserId == employeeId));
        }

        public void AddRoles(int employeeId, IEnumerable<int> rolesIds)
        {
            IEnumerable<IdentityUserRole<int>> rolesBatch = rolesIds.Select(role => new IdentityUserRole<int>() { RoleId = role, UserId = employeeId });
            _unitWork.EmployeeRole.AddBatch(rolesBatch);
        }

        // payroll methods
        public IEnumerable<MonthlyPayRollVM> GetMonthPayRoll()
        {
            return _unitWork.Employee.GetMonthPayRoll().Select(employee => new MonthlyPayRollVM()
            {
                EmployeeId = employee.Id,
                Nombre = $"{employee.ApellidoPaterno} {employee.ApellidoMaterno} {employee.Nombre}",
                Deposito = employee.Base - employee.DeduccionAhorro - employee.DeduccionDesayuno - employee.DeduccionGasolina
            });
        }

        public List<PayRollVM> GetEmployeeMonthlyPayRoll(int id)
        {
            Employee employee = _unitWork.Employee.GetEmployeeMonthlyPayRoll(id);

            // generate data for each month the user has been active
            DateTime maxDate = employee.Activo ? DateTime.Now.Date : employee.FechaBaja.Date;
            int monthDiff = (maxDate.Year - employee.FechaIngreso.Year) * 12 + maxDate.Month - employee.FechaIngreso.Month;

            if (monthDiff >= 0)
            {
                List<PayRollVM> payroll = new List<PayRollVM>();
                for (int i = 0; i <= monthDiff; i++)
                {
                    payroll.Add(new PayRollVM()
                    {
                        Deposito = employee.Base - employee.DeduccionAhorro - employee.DeduccionDesayuno - employee.DeduccionGasolina,
                        Month = maxDate.Month,
                        MonthName = CultureInfo.GetCultureInfo("es").DateTimeFormat.GetMonthName(maxDate.Month),
                        Year = maxDate.Year
                    });
                    maxDate = maxDate.AddMonths(-1);
                }
                return payroll;
            }
            return null;
        }

        public PayRollDetailVM GetEmployeeMonthPayRoll(int id, int year, int month)
        {
            Employee employee = _unitWork.Employee.GetEmployeeMonthlyPayRoll(id);
            DateTime maxDate = employee.Activo ? DateTime.Now.Date : employee.FechaBaja.Date;

            int yearInMonths = (year * 12 + month);
            if ( (employee.FechaIngreso.Year * 12 + employee.FechaIngreso.Month) <= yearInMonths && yearInMonths <= (maxDate.Year * 12 + maxDate.Month) )
            {
                return new PayRollDetailVM()
                {
                    Id = employee.Id,

                    Nombre = employee.Nombre,
                    ApellidoPaterno = employee.ApellidoPaterno,
                    ApellidoMaterno = employee.ApellidoMaterno,

                    Base = employee.Base,
                    Ahorros = employee.DeduccionAhorro,
                    Gasolina = employee.DeduccionGasolina,
                    Desayunos = employee.DeduccionDesayuno,
                    
                    Month = month,
                    MonthName = CultureInfo.GetCultureInfo("es").DateTimeFormat.GetMonthName(month),
                    Year = year
                };
            }
            return null;
        }
    }
}
