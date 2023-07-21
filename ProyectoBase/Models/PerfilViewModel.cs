using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PerfilViewModel
    {
        public int ClavePerfil { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre del Perfil")]
        public string NombrePerfil { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
