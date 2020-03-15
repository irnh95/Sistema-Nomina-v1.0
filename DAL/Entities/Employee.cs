using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Employee : IdentityUser<int>
    {
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

        [Required]
        public DateTime FechaIngreso { get; set; }
    }
}
