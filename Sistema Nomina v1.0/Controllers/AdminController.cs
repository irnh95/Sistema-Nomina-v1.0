using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sistema_Nomina_v1._0.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : ApplicationController
    {
        public AdminController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, ILogger<HomeController> logger, IMapper mapper) : base(userManager, signInManager, logger, mapper)
        {
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_employeeLogic.GetEmployees());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.Roles = _roleLogic.GetRoles();
            return View(new EmployeeVM());
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM employeeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeLogic.Register(employeeVM);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
            }

            ViewBag.Roles = _roleLogic.GetRoles();
            return View(employeeVM);

        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}