using AutoMapper;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Nomina_v1._0.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<IdentityUserRole<int>, EmployeeRoleVM>();
            CreateMap<EmployeeRoleVM, IdentityUserRole<int>>();

            CreateMap<IdentityRole<int>, RoleVM>();
            CreateMap<RoleVM, IdentityRole<int>>();
        }
    }
}
