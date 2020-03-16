using AutoMapper;
using BLL.Logic;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Nomina_v1._0.Controllers
{
    public class ApplicationController : Controller
    {

        protected readonly ILogger<HomeController> _logger;
        protected readonly SignInManager<Employee> _signInManager;
        protected readonly IMapper _mapper;
        protected readonly EmployeeLogic _employeeLogic;
        protected readonly RoleLogic _roleLogic;

        public ApplicationController(
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            ILogger<HomeController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _signInManager = signInManager;
            _mapper = mapper;

            _employeeLogic = new EmployeeLogic(_mapper, userManager);
            _roleLogic = new RoleLogic(_mapper);
        }
    }
}
