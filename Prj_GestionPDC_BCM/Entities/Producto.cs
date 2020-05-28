using System;
using System.Collections.Generic;

namespace Prj_GestionPDC_BCM.Entities
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public bool Active { get; set; }
    }
}
