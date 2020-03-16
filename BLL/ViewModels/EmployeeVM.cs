using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.ViewModels
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            FechaIngreso = DateTime.Now.Date;
        }

        [Required]
        public int Id { get; set; }
        public string UserName { get { return Email; } }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Sueldo Base")]
        [DefaultValue(0)]
        public decimal Base { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Deducción por Desayuno")]
        [DefaultValue(0)]
        public decimal DeduccionDesayuno { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Deducción de Ahorro")]
        [DefaultValue(0)]
        public decimal DeduccionAhorro { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Deducción de Gasolina")]
        [DefaultValue(0)]
        public decimal DeduccionGasolina { get; set; }



        [DefaultValue(true)]
        public bool Activo { get; set; }

        [Required]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaBaja { get; set; }

        public ICollection<int> employeeRoleId { get; set; }
        public ICollection<EmployeeRoleVM> employeeRole { get; set; }
    }
}
