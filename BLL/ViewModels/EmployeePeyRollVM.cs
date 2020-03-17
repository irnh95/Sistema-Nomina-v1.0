using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class EmployeePeyRollVM
    {
        public EmployeeVM EmployeeVM { get; set; }
        public IEnumerable<PayRollVM> PayRollsVM { get; set; }
        public PayRollVM PayRollVM { get; set; }
    }
}
