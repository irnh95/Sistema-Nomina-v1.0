using DAL.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRoleRepo : Repository<IdentityUserRole<int>>
    {
        public EmployeeRoleRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
