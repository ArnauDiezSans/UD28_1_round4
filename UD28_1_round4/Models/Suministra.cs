using System;
using System.Collections.Generic;

namespace UD28_1_round4.Models
{
    public partial class Suministra
    {
        public int CodigoPieza { get; set; }
        public string IdProveedor { get; set; }
        public int? Precio { get; set; }

        public virtual Piezas CodigoPiezaNavigation { get; set; }
        public virtual Proveedores IdProveedorNavigation { get; set; }
    }
}
