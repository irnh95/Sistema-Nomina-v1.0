using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.ViewModels
{
    public class PayRollVM
    {
        [Display(Name = "Mes")]
        public int Month { get; set; }
        [Display(Name = "Mes")]
        public string MonthName { get; set; }
        [Display(Name = "Año")]
        public int Year { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Deposito { get; set; }
    }
}