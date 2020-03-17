using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.ViewModels
{
    public class PayRollDetailVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get { return $"{ApellidoPaterno} {ApellidoMaterno} {Nombre}"; } }


        [Display(Name = "Mes")]
        public int Month { get; set; }
        [Display(Name = "Mes")]
        public string MonthName { get; set; }
        [Display(Name = "Año")]
        public int Year { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Ingreso base")]
        public decimal Base { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Total Percepciones")]
        public decimal Percepciones { get { return Base; } }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Retención por ahorro")]
        public decimal Ahorros { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Desayunos")]
        public decimal Desayunos { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Utilizado en targeta Gasmart")]
        public decimal Gasolina { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Total Deducciones")]
        public decimal Deducciones { get { return Ahorros + Desayunos + Gasolina; } }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Deposito")]
        public decimal Deposito { get { return Percepciones - Deducciones; } }
    }
}