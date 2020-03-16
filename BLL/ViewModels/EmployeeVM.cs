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
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Base { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeduccionDesayuno { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeduccionAhorro { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeduccionGasolina { get; set; }



        [DefaultValue(true)]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }

        public DateTime FechaBaja { get; set; }

        public ICollection<EmployeeRoleVM> employeeRole { get; set; }
    }
}
