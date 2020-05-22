﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prj_GestionPDC_BCM.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            RolUsuario = new HashSet<RolUsuario>();
        }

      
        public int Id { get; set; }

      
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int Creditos { get; set; }

        public virtual ICollection<RolUsuario> RolUsuario { get; set; }
    }
}
