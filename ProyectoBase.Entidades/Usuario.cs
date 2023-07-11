using System;

namespace ProyectoBase.Entidades
{
    public class Usuario
    {
        public int ClaveUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
        public int Cuenta { get; set; }
        public bool EsAdmin { get; set; }
        public string NombreTrabajador { get; set; }
        public int ClaveDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int ClavePerfil { get; set; }
        public string NombrePuesto { get; set; }
        public int ClavePuesto { get; set; }
        public int ClaveArea { get; set; }
        public string Correo { get; set; }
        public int NumeroIntentoLogin { get; set; }
    }
}
