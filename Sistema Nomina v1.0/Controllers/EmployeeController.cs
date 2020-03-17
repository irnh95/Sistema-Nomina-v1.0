using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Logic;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sistema_Nomina_v1._0.Controllers
{
    [Authorize]
    public class EmployeeController : ApplicationController
    {
        public EmployeeController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, ILogger<HomeController> logger, IMapper mapper) : base(userManager, signInManager, logger, mapper)
        {
        }

        // GET: Employee
        public ActionResult Index(int? id = null)
        {
            if (Helpers.Helpers.IsUserActive(User.Identity.Name, _employeeLogic))
            {
                ModelState.AddModelError(string.Empty, "Usuario Desabilitado.");
                return RedirectToAction("LogOut", "Account");
            }

            EmployeeVM employeeVM =
                (id != null && User.IsInRole("Admin")) ?
                    _employeeLogic.GetEmployeById((int)id) :
                    _employeeLogic.GetEmployeByEmail(User.Identity.Name);

            IEnumerable<PayRollVM> payRollVM = _employeeLogic.GetEmployeeMonthlyPayRoll(employeeVM.Id);

            return View(new EmployeePeyRollVM() { EmployeeVM = employeeVM, PayRollsVM = payRollVM });
        }

        // GET: Employee/Details/5
        public ActionResult Details(int year, int month, int? id = null)
        {
            if (Helpers.Helpers.IsUserActive(User.Identity.Name, _employeeLogic))
            {
                ModelState.AddModelError(string.Empty, "Usuario Desabilitado.");
                return RedirectToAction("LogOut", "Account");
            }

             id = (id != null && User.IsInRole("Admin")) ? (int)id : Int32.Parse(_signInManager.UserManager.GetUserId(User));

            PayRollDetailVM payRollVM = _employeeLogic.GetEmployeeMonthPayRoll((int)id, year, month);

            return View( payRollVM );
        }
    }
}