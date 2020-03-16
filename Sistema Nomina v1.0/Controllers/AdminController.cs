﻿using System;
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
                    IdentityResult result = _employeeLogic.Create(employeeVM);
                    if (result.Succeeded)
                    {

                        if (employeeVM.employeeRoleId != null)
                        {
                            _employeeLogic.AddRoles(_employeeLogic.GetEmployeIdByEmail(employeeVM.Email), employeeVM.employeeRoleId);
                        }
                        _employeeLogic.Commit();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            if(error.Code == "DuplicateUserName")
                            ModelState.AddModelError("Email", "El correo ya esta en uso.");
                        }
                    }
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
            ViewBag.Roles = _roleLogic.GetRoles();
            return View(_employeeLogic.GetEmployeById(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeVM employeeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // update roles
                    _employeeLogic.DeleteEmployeeRoles(id);
                    if (employeeVM.employeeRoleId != null)
                    {
                        _employeeLogic.AddRoles(id, employeeVM.employeeRoleId);
                    }

                    //edit
                    _employeeLogic.Update(employeeVM);
                    _employeeLogic.Commit();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }
            ViewBag.Roles = _roleLogic.GetRoles();
            return View(employeeVM);
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