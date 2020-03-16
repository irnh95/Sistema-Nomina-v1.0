using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class EmployeeRoleVM
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }


        public RoleVM employeeRoles { get; set; }
    }
}
