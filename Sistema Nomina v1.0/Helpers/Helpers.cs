using BLL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Nomina_v1._0.Helpers
{
    public static class Helpers
    {
        public static bool IsUserActive(string email, EmployeeLogic _employeeLogic)
        {
            return !_employeeLogic.isEmployeeActive(email);
        }
    }
}
