using System;
using System.Collections.Generic;

namespace UD28_1_round4.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
