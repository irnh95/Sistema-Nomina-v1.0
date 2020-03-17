using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.ViewModels
{
    public class MonthlyPayRollVM
    {
        public int EmployeeId { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Deposito { get; set; }
    }
}
