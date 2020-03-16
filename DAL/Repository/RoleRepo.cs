using DAL.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class RoleRepo : Repository<IdentityRole<int>>
    {
        public RoleRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
