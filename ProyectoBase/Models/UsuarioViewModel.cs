using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBase.Models
{
    public class UsuarioViewModel
    {
        public int ClaveUsuario { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Contraseña")]
        [StringLength(50, ErrorMessage = "La Cantidad de caracteres es inferior a la permitida(5)", MinimumLength = -1)]
        public string Contrasena { get; set; }
        
        public bool Activo { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Cuenta")]
        public int Cuenta { get; set; }
        
        public bool EsAdmin { get; set; }
        
        public string NombreTrabajador { get; set; }
        
        public int ClaveDepartamento { get; set; }
        
        public string NombreDepartamento { get; set; }
        
        public int ClavePerfil { get; set; }
        
        public string NombrePuesto { get; set; }
        
        public int  ClavePuesto { get; set; }
        
        public int ClaveArea { get; set; }
        
        public string Correo { get; set; }
        public int NumeroIntentoLogin { get; set; }
        public string NombrePerfil { get; set; }
    }
}
